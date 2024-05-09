using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Model;

namespace XcelTech.HRMS.Bloc.IService
{
    public interface IDepartmentService
    {
        Task<IActionResult> createDepartment(Department department);
        Task<ActionResult<List<string>>> getAllDepartment();

    }
}
