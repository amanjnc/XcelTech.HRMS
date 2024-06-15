using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XcelTech.HRMS.Bloc.IService;
using XcelTech.HRMS.Model.Model;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace XcelTech.HRMS.Api.Controllers.EmployeeController
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {

        private readonly IDepartmentService _departmentService;

        public DepartmentController( IDepartmentService department)
        {
            _departmentService = department;
            

        }

        //[Authorize(Policy = "ManageDepartment")]
        [HttpPost("CreateNewDepartment")]
        public async Task<IActionResult> CreateDepartment([FromBody] Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _departmentService.createDepartment(department);

            

        }

        
        //[Authorize(Roles = "employee")]
        [HttpGet("GetAllDepartment")]
        [ProducesResponseType(typeof(IEnumerable<Department>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<Department>>> getAllDepartment()
        {
            return await _departmentService.getAllDepartment();

        }
        [HttpGet("GetAllDepartmentNames")]
        public async Task<ActionResult<List<string>>> getAllDepartmentNames()
        {
            return await _departmentService.getAllDepartmentNames();

        }

    }
}
