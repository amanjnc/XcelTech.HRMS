using Microsoft.AspNetCore.Mvc;
using XcelTech.HRMS.Bloc.IService;
using XcelTech.HRMS.Model.Dto;
using Microsoft.AspNetCore.Authorization;
using System;
using XcelTech.HRMS.Model.Model;
using System.Security.Claims;

namespace XcelTech.HRMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeControllers : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeControllers(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }



        [Authorize]
        [HttpPatch("AddProfile")]
        public async Task<IActionResult> AddProfile([FromBody] ProfileInfoDto profileInfoDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //var claimsIdentity = User.Identity as ClaimsIdentity;
                    //var userEmail = claimsIdentity.FindFirst(ClaimTypes.Email)?.Value;


                    var result = await _employeeService.updateEmployee(profileInfoDto);
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
    }
}