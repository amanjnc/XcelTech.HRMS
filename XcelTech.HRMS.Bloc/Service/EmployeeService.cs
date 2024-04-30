using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Bloc.IService;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo.IRepo;

namespace XcelTech.HRMS.Bloc.Service
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {

            _employeeRepository = employeeRepository;

        }

        public async  Task<IActionResult> addEmploee(Employee employee)
        {
            //var CreatedUser = await _accountRegister.createUser(appUser, dtoRegister.Password, employee);
            await _employeeRepository.addEmployyetoTable(employee);

            return new OkObjectResult(employee);




        }
    }
}
