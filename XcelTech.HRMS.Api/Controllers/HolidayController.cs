using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Bloc.IService;

namespace XcelTech.HRMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayController : ControllerBase
    {
        private readonly IHolidayService _holidayService;

        public HolidayController(IHolidayService holidayService)
        {
            _holidayService = holidayService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Holiday>>> GetAllHolidays()
        {
            var holidays = await _holidayService.GetAllHolidays();
            return Ok(holidays);
        }

        /*[HttpGet]
        public async Task<ActionResult<Holiday>> GetHolidayById([FromQuery] int id)
        {
            var holiday = await _holidayService.GetHolidayById(id);
            if (holiday == null) return NotFound();
            return Ok(holiday);
        }*/

        [HttpPost]
        public async Task<ActionResult<Holiday>> CreateHoliday([FromForm]Holiday holiday)
        {
            var createdHoliday = await _holidayService.CreateHoliday(holiday);
            //return CreatedAtAction(nameof(GetHolidayById), new { id = createdHoliday.HolidayId }, createdHoliday);
            return Ok(createdHoliday);
        }

       /* [HttpPut("{id}")]
        public async Task<ActionResult<Holiday>> UpdateHoliday(Holiday holiday)
        {
            var updatedHoliday = await _holidayService.UpdateHoliday(holiday);
            if (updatedHoliday == null) return NotFound();
            return Ok(updatedHoliday);
        }*/

        [HttpDelete]
        public async Task<IActionResult> DeleteHoliday([FromQuery] int id)
        {
            var deleted = await _holidayService.DeleteHoliday(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
