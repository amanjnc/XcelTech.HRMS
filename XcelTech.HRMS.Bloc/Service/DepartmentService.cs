using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
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
using XcelTech.HRMS.Repo.Repo;

namespace XcelTech.HRMS.Bloc.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IValidator<Department> _validator;


        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService( IDepartmentRepository departmentRepository, IValidator<Department> validator)
        {
            _validator = validator;
            _departmentRepository = departmentRepository;
            
        }
        public async Task<IActionResult> createDepartment(Department department)
        {
            //remeber you have to check if the department doesnt already exists

            var validationResult = await _validator.ValidateAsync(department);
            if (!validationResult.IsValid)
            {
                    var validationErrors = new List<string>();
                    foreach (var error in validationResult.Errors)
                    {
                        validationErrors.Add($"{error.PropertyName}: {error.ErrorMessage}");
                    }
                    return new BadRequestObjectResult(validationErrors);
            }
            string departmentName = department.DepartmentName;

            if (await _departmentRepository.isNewDepartment(departmentName))
            {
                await _departmentRepository.createDepartment(department);
                return new OkObjectResult(department);
            }
            return new BadRequestObjectResult("Invalid, department already exists.");









        }

        public async Task<ActionResult<List<Department>>> getAllDepartment()
        {
            return await _departmentRepository.getAllDepartment();
        }

        public async Task<ActionResult<List<string>>> getAllDepartmentNames()
        {
            return await _departmentRepository.getAllDepartmentNames();
        }
    }
}
