using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using XcelTech.HRMS.Bloc.IService;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo;

namespace XcelTech.HRMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeFileController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IEmployeeFileService _employeeFileService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public EmployeeFileController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment, IEmployeeFileService employeeFileService)
        {
            _applicationDbContext = context;
            _hostingEnvironment = hostingEnvironment;
            _employeeFileService = employeeFileService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployeeFile([FromBody] EmployeeFileDto employeeFileDto, [FromQuery] int userId)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                int UserId = userId;

                var result= await _employeeFileService.CreateEmployeeFile(employeeFileDto, UserId);
                
                return Ok(result);
 

                //return Ok(new { Message = "Files uploaded successfully", EmployeeFile = employeeFile });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetEmployeeFiles([FromQuery] int userId)
        {
            try
            {
                int UserId = userId;

                var result = await _employeeFileService.GetEmployeeFileById(UserId);

                return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteEmployeeFiles([FromQuery] int userId)
        {

            int UserId = userId;

            var result = await _employeeFileService.DeleteEmployeeFile(UserId);

            return Ok(result);
        }


    }

}