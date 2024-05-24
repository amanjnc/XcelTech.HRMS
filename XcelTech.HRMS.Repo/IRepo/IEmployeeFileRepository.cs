using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Model;

namespace XcelTech.HRMS.Repo.IRepo
{
    public interface IEmployeeFileRepository
    {
        Task CreateEmployeeFile(EmployeeFile employeeFile);
        Task<EmployeeFile> GetEmployeeFile(int UserId);

        Task<EmployeeFile> DeleteEmployeeFile(int UserId);
    }
}
