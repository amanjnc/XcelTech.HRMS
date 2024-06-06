using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Security.Claims;
using XcelTech.HRMS.Bloc.IService;
using XcelTech.HRMS.Bloc.Service;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace XcelTech.HRMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayRollController : ControllerBase
    {
        private readonly IPayRollService _payRollService;

        public PayRollController(IPayRollService payRollService)
        {
            _payRollService = payRollService;
        }

        
        [HttpPost]
     
        public async Task<IActionResult> CreatePayroll([FromForm] PayRollPostDto payrollpost)
        {
            if (ModelState.IsValid)
            {
               
                var result = await _payRollService.createPayroll(payrollpost);

                return Ok(result);
            }

            return BadRequest(ModelState);
        }

        [HttpGet("getAllPayRolls")]
        public async Task<ActionResult<IEnumerable<PayRollGetDto>>> getAllPayRolls()
        {
            try
            {
                var leaves = await _payRollService.getAllPayRolls();


                return Ok(leaves);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("by-employee/{employeeId}")]
        public async Task<ActionResult<IEnumerable<Payroll>>> GetPayrollsByEmployeeId(int employeeId)
        {
            var payrolls = await _payRollService.GetPayrollsByEmployeeId(employeeId);
            if (payrolls == null || !payrolls.Any())
            {
                return NotFound();
            }
            return Ok(payrolls);
        }

        [HttpGet("by-start-date/{startDate}")]
        public async Task<ActionResult<IEnumerable<Payroll>>> GetPayrollsByStartDate(string startDate)
        {
            if (!DateOnly.TryParse(startDate, out var parsedDate))
            {
                return BadRequest("Invalid date format. Use 'YYYY-MM-DD'.");
            }

            var payrolls = await _payRollService.GetPayrollsByStartDate(parsedDate);
            if (payrolls == null || !payrolls.Any())
            {
                return NotFound();
            }
            return Ok(payrolls);
        }
    }

}
