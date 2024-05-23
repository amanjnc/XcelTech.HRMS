﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo.IRepo;

namespace XcelTech.HRMS.Repo.Repo
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _applicationDbContext;


        public EmployeeRepository( IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, ApplicationDbContext applicationDbContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
        }

        public async Task addEmployyetoTable(Employee employee)
        {
            Console.WriteLine("not def shit");

            _applicationDbContext.Employees.Add(employee);
            await _applicationDbContext.SaveChangesAsync();
        
        }

       
        public async Task updateEmployee(Employee employee,string email)
        {
            //var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            var existingEmployee = await _applicationDbContext.Employees.FirstOrDefaultAsync(emp => emp.EmployeeEmail == email);

            if (existingEmployee == null)
            {
                throw new Exception("Employee not found.");
            }

            //existingEmployee.EmployeeAge = employee.EmployeeAge;
            existingEmployee.EmployeeAddress = employee.EmployeeAddress;
            //existingEmployee.DepartmentId = employee.DepartmentId;





            //var employeeType = typeof(Employee);

            //var properties = employeeType.GetProperties();

            //foreach (var property in properties)
            //{
            //    var inputValue = property.GetValue(employee);
            //    if (inputValue != null)
            //    {
            //        property.SetValue(existingEmployee, inputValue);
            //    }
            //}
            Console.WriteLine("notllskdfjalksjd founs world!");

            await _applicationDbContext.SaveChangesAsync();
        }


        public async Task<Employee> GetEmployeeByAppUserIdAsync(string appUserId)
        {
            try
            {
                return await _applicationDbContext.Employees
                    .Include(e => e.AppUser)
                    .FirstOrDefaultAsync(e => e.AppUserId == appUserId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching employee by AppUserId: {ex.Message}");
            }
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            var employees = await _applicationDbContext.Employees
                .Select(e => new Employee
                {

                    EmployeePhone= e.EmployeePhone,
                    EmployeeId = e.EmployeeId,
                    Gender = e.Gender,
                    EmployyDOB = e.EmployyDOB,
                    EmployeeAddress = e.EmployeeAddress,
                    EmployeeImage = e.EmployeeImage,
                    EmployeeFirstName = e.EmployeeFirstName,
                    EmployeeLastName = e.EmployeeLastName,
                    EmployeeEmail = e.EmployeeEmail,
                    PhotoId = e.PhotoId,
                    DepartmentId = e.DepartmentId,
                    AppUser = e.AppUser

                })
                .ToListAsync();

            return employees;
        }
        public async Task<bool> DeleteEmployee(Employee employee)
        {
            try
            {
                _applicationDbContext.Employees.Remove(employee);
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting employee: {ex.Message}");
            }
        }

    }
}
