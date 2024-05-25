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
        [HttpPost]
        public async Task<IActionResult> FillAttendance([FromForm] AttendanceDto attendanceDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                var email = HttpContext.User.FindFirstValue(ClaimTypes.Email);


                var result = await _attendanceService.AddAttendance(attendanceDto, email);

                return Ok(result); // Optionally return the newly created leave
            }
            catch (Exception ex)
            {
                // Handle any errors
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }


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
