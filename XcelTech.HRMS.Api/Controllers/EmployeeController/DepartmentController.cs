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

        //[Authorize(Policy = "ViewDepartment")]
        [HttpPost("CreateNewDepartment")]
        public async Task<IActionResult> CreateDepartment([FromBody] Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _departmentService.createDepartment(department);

            

        }

        ////[Authorize(Policy = "ManageDepartment")]
        //[Authorize(Roles = "admin")]
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













        // GET: DepartmentController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: DepartmentController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: DepartmentController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: DepartmentController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: DepartmentController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: DepartmentController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: DepartmentController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: DepartmentController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
