using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Dto;

namespace XcelTech.HRMS.Bloc.IService
{
    public interface IEmployeeFileService
    {
        Task<IActionResult> CreateEmployeeFile(EmployeeFileDto employeeFileDto,int UserId);

        Task<EmployeeFileDto> GetEmployeeFileById(int UserId);

        Task<IActionResult> DeleteEmployeeFile(int UserId);
    }
}
