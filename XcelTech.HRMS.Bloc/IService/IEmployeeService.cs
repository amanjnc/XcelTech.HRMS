using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;

namespace XcelTech.HRMS.Bloc.IService
{
    public interface IEmployeeService
    {
        public Task<IActionResult> addEmployee(Employee employee);
        public Task<IActionResult> updateEmployee(EmployeeGetDto employeeGetDto);
        public Task<List<EmployeeGetDto>> getAllEmployeesAsync();
        public Task<IActionResult> deleteEmployeeUserByEmail(string Email);


    }
}
