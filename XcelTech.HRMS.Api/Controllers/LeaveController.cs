using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
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

        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(LeaveDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> RequestLeave([FromForm] LeaveDto leaveDto) {

            if (!ModelState.IsValid)
            {
                Console.WriteLine("thiss");
                return BadRequest(ModelState);
            }

            try
            {
               
                var email = HttpContext.User.FindFirstValue(ClaimTypes.Email);
                Console.WriteLine("email");
                Console.WriteLine(email);
                    


                var result = await _leaveService.createLeave(leaveDto, email);

                return Ok(result); // Optionally return the newly created leave
            }
            catch (Exception ex)
            {
                // Handle any errors
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }


        }

        [Authorize]
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

        [Authorize]
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


        [HttpGet("getAllLeavesTypes")]
        public async Task<List<string>> GetAllLeaveTypesAsync()
        {
            var leaveTypes = await _applicationDbContext.LeaveTypes
                .Select(l => l.LeaveTypeName)
                .Distinct()
                .ToListAsync();

            return leaveTypes;
        }

        
        [HttpPost("AddLeaveType")]
        public async Task<LeaveTypes> AddLeaveType(string leaveTypeName)
        {
            // Check if the leave type already exists
            var existingLeaveType = await _applicationDbContext.LeaveTypes
                .Where(l => l.LeaveTypeName == leaveTypeName)
                .FirstOrDefaultAsync();

            if (existingLeaveType != null)
            {
                return existingLeaveType;
            }

            var newLeave = new LeaveTypes
            {
                LeaveTypeName = leaveTypeName,
            };

            _applicationDbContext.LeaveTypes.Add(newLeave);
            await _applicationDbContext.SaveChangesAsync();

            return newLeave;
        }



    }
}
