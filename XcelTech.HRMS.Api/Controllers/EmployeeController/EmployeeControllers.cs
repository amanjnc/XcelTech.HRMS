using Microsoft.AspNetCore.Mvc;
using XcelTech.HRMS.Bloc.IService;
using XcelTech.HRMS.Model.Dto;
using Microsoft.AspNetCore.Authorization;
using System;
using XcelTech.HRMS.Model.Model;
using System.Security.Claims;
using XcelTech.HRMS.Bloc.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Net;

namespace XcelTech.HRMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeControllers : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IRegisterService _registerService;
        private readonly IFilehandleService _filehandleService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EmployeeControllers(IEmployeeService employeeService, IRegisterService registerService, IFilehandleService filehandleService, IWebHostEnvironment webHostEnvironment)
        {
            _employeeService = employeeService;
            _registerService = registerService;
            _filehandleService = filehandleService;
            _webHostEnvironment = webHostEnvironment;
        }

        [Authorize]
        [HttpPatch("updateProfile")]
        public async Task<IActionResult> updateProfile([FromBody] ProfileInfoDto profileInfoDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var email = HttpContext.User.FindFirstValue(ClaimTypes.Email);
                    Console.WriteLine($"current email: {email}");
                    var result = await _employeeService.updateEmployee(profileInfoDto, email);
                    Console.WriteLine("not Hello, world!");

                    return Ok(result);
                }

                Console.WriteLine("Hello, world!");
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("registerProfile")]
        
        public async Task<IActionResult> registerProfile([FromForm] ProfileInfoDto profileInfoDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //var _uploadedfiles = Request.Form.Files;
                    //string imagepath = await _filehandleService.FilehandlePath(_uploadedfiles, profileInfoDto.EmployeeEmail);
                    var result = await _registerService.createUser(profileInfoDto);
                    return Ok(result);
                }

                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("getAllEmployeesInfo")]
        [ProducesResponseType(typeof(IEnumerable<EmployeeGetDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<EmployeeGetDto>>> getAllEmployee()
        {
            try
            {
                var employees = await _employeeService.getAllEmployeesAsync();


                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("delateEmployeeUserByEmail")]
        public async Task<IActionResult> deleteEmployeeUserByEmail(string Email)
        {
             var result = await _employeeService.deleteEmployeeUserByEmail(Email);
             return Ok(result);

        }



    }
}