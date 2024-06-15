using AutoMapper;
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
        private readonly IMapper _mapper;

        public LeaveController(ApplicationDbContext applicationDbContext, ILeaveService leaveService, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _leaveService = leaveService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost]
        //[ProducesResponseType(typeof(LeaveDto), (int)HttpStatusCode.OK)]
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

                return Ok(result); 
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
            try
            {
                var result = await _leaveService.ApproveLeaveAsync(leaveId);

                if (!result.Success)
                {
                    return BadRequest(result.Message);
                }

                return Ok(result.Message);
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
        public async Task<ActionResult<IEnumerable<GetLeaveDto>>> getAllLeaves()
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
        public async Task<LeaveTypeDto> AddLeaveType([FromBody] LeaveTypeDto leaveType)
        {
            // Check if the leave type already exists
            var existingLeaveType = await _applicationDbContext.LeaveTypes
                .Where(l => l.LeaveTypeName == leaveType.LeaveTypeName)
                .FirstOrDefaultAsync();

            var _leaveType = _mapper.Map<LeaveTypes>(leaveType);


            _applicationDbContext.LeaveTypes.Add(_leaveType);
            await _applicationDbContext.SaveChangesAsync();

            return leaveType;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteLeaveRequest([FromQuery] int LeaveId)
        {

            int leaveId = LeaveId;

            var result = await _leaveService.DeleteLeave(leaveId);

            return Ok(result);
        }



    }
}
