using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XcelTech.HRMS.Bloc.IService;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Model.Dto;
using System.Security.Claims;

namespace XcelTech.HRMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class WeeklyReportController : ControllerBase
    {
        private readonly IWeeklyReportService _weeklyReportService;

        public WeeklyReportController(IWeeklyReportService weeklyReportService)
        {
            _weeklyReportService = weeklyReportService;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<ReportGetDto>>> GetAllReports()
        {
            var reports = await _weeklyReportService.GetAllReportsAsync();
            return Ok(reports);
        }

        [HttpGet("byId")]
        public async Task<ActionResult<ReportGetDto>> GetReportById(int id)
        {
            var report = await _weeklyReportService.GetReportByIdAsync(id);
            if (report == null)
            {
                return NotFound();
            }
            return Ok(report);
        }

        [HttpPost]
        public async Task<ActionResult<WeeklyReport>> CreateReport([FromBody] ReportDto dto)
        {
            var userEmail = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            if (string.IsNullOrEmpty(userEmail))
            {
                return Unauthorized();
            }

            var report = await _weeklyReportService.CreateReportAsync(dto, userEmail);
            return CreatedAtAction(nameof(GetReportById), new { id = report.ReportId }, report);
        }

        [HttpPut]
        public async Task<ActionResult<WeeklyReport>> UpdateReport([FromQuery]int id, [FromBody] ReportDto dto)
        {
            try
            {
                var report = await _weeklyReportService.UpdateReportAsync(id, dto);
                return Ok(report);
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteReport([FromQuery] int id)
        {
            var success = await _weeklyReportService.DeleteReportAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("loggedinuser")]
        public async Task<IEnumerable<ReportGetDto>> GetReportsByLoggedInEmail()
        {
            var userEmail = HttpContext.User.FindFirstValue(ClaimTypes.Email);
           

            return await _weeklyReportService.GetUsersReport(userEmail);
        }
    }

}
