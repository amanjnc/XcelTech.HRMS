//using Microsoft.AspNetCore.Mvc;
//using XcelTech.HRMS.Bloc.IService;
//using XcelTech.HRMS.Model.Dto;
//using Microsoft.AspNetCore.Authorization;
//using System;
//using XcelTech.HRMS.Model.Model;

//namespace XcelTech.HRMS.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class EmployeeController : ControllerBase
//    {
//        private readonly IEmployeeService _employeeService;

//        public EmployeeController(IEmployeeService employeeService)
//        {
//            _employeeService = employeeService;
//        }

//        [Authorize("employee")]
//        [HttpPost("Create")]
//        public IActionResult Create([FromBody] Employee employee)
//        {
//            try
//            {
//                if (ModelState.IsValid)
//                {
//                    var result = _employeeService.addEmploee(employee);
//                    return Ok(result);
//                }
//                return BadRequest(ModelState);
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, ex.Message);
//            }
//        }
//    }
//}