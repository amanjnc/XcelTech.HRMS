using Microsoft.AspNetCore.Mvc;
using XcelTech.HRMS.Bloc.IService;
using XcelTech.HRMS.Model.Dto;
using Microsoft.AspNetCore.Authorization;
using System;
using XcelTech.HRMS.Model.Model;
using System.Security.Claims;
using XcelTech.HRMS.Bloc.Service;

namespace XcelTech.HRMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeControllers : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IRegisterService _registerService;

        public EmployeeControllers(IEmployeeService employeeService, IRegisterService registerService)
        {
            _employeeService = employeeService;
            _registerService = registerService;
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


            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        var result = _employeeService.addEmploee(employee);
            //        return Ok(result);
            //    }
            //    return BadRequest(ModelState);
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, ex.Message);
            //}





        }

        [HttpPost("registerProfile")]
        public async Task<IActionResult> registerProfile([FromForm] ProfileInfoDto profileInfoDto)
        {
             try
            {

                if (ModelState.IsValid)
                {
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




    }
}