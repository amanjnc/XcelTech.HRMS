using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using XcelTech.HRMS.Bloc.IService;
using XcelTech.HRMS.Bloc.Service;
using XcelTech.HRMS.Model.Dto;

namespace XcelTech.HRMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;
        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
            
        }
        [HttpPost("Clockin")]
        public async Task<IActionResult> Clockin([FromBody]AttendanceClockin _clockinTime)
        {

            try
            {

                var email = HttpContext.User.FindFirstValue(ClaimTypes.Email);



                var result = await _attendanceService.Clockin(_clockinTime, email);

                return Ok(result); 
            }
            catch (Exception ex)
            {
                // Handle any errors
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }


        }

        [HttpPatch("Clockout")]
        public async Task<IActionResult> ClockOut([FromBody] AttendanceClockin _clockoutTime)
        {

            try
            {

                var email = HttpContext.User.FindFirstValue(ClaimTypes.Email);


                var result = await _attendanceService.Clockout(_clockoutTime, email);

                return Ok(result); 
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }


        }

        [HttpGet("GetAllAttendances")]
        public async Task<ActionResult<IEnumerable<AttendanceDto>>> GetAllAttendances()
        {
            try
            {
                var leaves = await _attendanceService.getAllAttendances();


                return Ok(leaves);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        [HttpDelete("delete-all")]
        public async Task<IActionResult> DeleteAllAttendances()
        {
            await _attendanceService.DeleteAllAttendances();
            return NoContent();
        }

        [HttpDelete("delete-by-employee/{employeeId}")]
        public async Task<IActionResult> DeleteAttendancesByEmployeeId(int employeeId)
        {
            await _attendanceService.DeleteAttendancesByEmployeeId(employeeId);
            return NoContent();
        }
        /*[HttpGet("GetTodaysAttendance")]

        public IActionResult GetTodaysAttendance()
        {
            try
            {
                // Get today's date
                Date today = DateTime.Today;

                var attendanceRecords = _attendanceService.GetTodaysAttendance(DateTime today);

                return Ok(attendanceRecords);
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log, return error response)
                return StatusCode(500);
            }
        }*/



    }
}
