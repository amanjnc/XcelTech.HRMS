using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Model;

namespace XcelTech.HRMS.Repo.IRepo
{
    public interface IDepartmentRepository
    {
        Task  createDepartment(Department department);
        Task<bool> isNewDepartment(string DepartmentName);

        public Task<ActionResult<int>> getDepartmentByName(string departmentName);
        public Task<ActionResult<List<Department>>> getAllDepartment();


    }
}
