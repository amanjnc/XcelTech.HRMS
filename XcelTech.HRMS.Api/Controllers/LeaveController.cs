using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using XcelTech.HRMS.Bloc.IService;
using XcelTech.HRMS.Bloc.Service;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo;

namespace XcelTech.HRMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {

        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ILeaveService _leaveService;

        public LeaveController(ApplicationDbContext applicationDbContext, ILeaveService leaveService)
        {
            _applicationDbContext = applicationDbContext;
            _leaveService = leaveService;
        }

        [HttpPost]

        public async Task<IActionResult> RequestLeave([FromForm] LeaveDto leaveDto) {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
               
                var email = HttpContext.User.FindFirstValue(ClaimTypes.Email);


                var result = await _leaveService.createLeave(leaveDto, email);

                return Ok(result); // Optionally return the newly created leave
            }
            catch (Exception ex)
            {
                // Handle any errors
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }


        }

        [HttpPatch("{leaveId}/approve")]
        public async Task<IActionResult> ApproveLeave(int leaveId)
        {
            var Status = "Approved";

            try
            {
                var result = await _leaveService.UpdateLeaveStatus(leaveId, Status);

                return Ok(result); // Optionally return the newly created leave
            }
            catch (Exception ex)
            {
                // Handle any errors
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }

        [HttpPatch("{leaveId}/disapprove")]
        public async Task<IActionResult> DisapproveLeave(int leaveId)
        {
            var Status = "Disapproved";

            try
            {
                var result = await _leaveService.UpdateLeaveStatus(leaveId, Status);

                return Ok(result); // Optionally return the newly created leave
            }
            catch (Exception ex)
            {
                // Handle any errors
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }

        [HttpGet("getAllLeaves")]
        public async Task<ActionResult<IEnumerable<Leave>>> getAllDepartment()
        {
            try
            {
                var leaves = await _leaveService.getAllLeaves();


                return Ok(leaves);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
