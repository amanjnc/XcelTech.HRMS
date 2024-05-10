using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
        private static IWebHostEnvironment _environment;

        public EmployeeRepository(ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IWebHostEnvironment environment)
        {
            _httpContextAccessor = httpContextAccessor;
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
            _environment = environment;
        }

        public async Task addEmployyetoTable(Employee employee)
        {

            _applicationDbContext.Employees.Add(employee);
            await _applicationDbContext.SaveChangesAsync();
        
        }

        public async Task<Employee> GetEmployeeProfile(string email)
        {
            var existingEmployee = await _applicationDbContext.Employees.FirstOrDefaultAsync(emp => emp.EmployeeEmail == email);

            /*if (existingEmployee == null)
            {
                throw new Exception("Employee not found.");
            }*/

            return existingEmployee;
        }


        public async Task updateEmployee(Employee employee,string email,string imagepath)
        {
            //var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);

            var existingEmployee = await _applicationDbContext.Employees.FirstOrDefaultAsync(emp => emp.EmployeeEmail == email);

            if (existingEmployee == null)
            {
                throw new Exception("Employee not found.");
            }

            var all= _environment.WebRootPath + "\\Images\\" + email;

            existingEmployee.EmployeeAge = employee.EmployeeAge;
            existingEmployee.EmployeeAddress = employee.EmployeeAddress;
            existingEmployee.DepartmentId = employee.DepartmentId;
            existingEmployee.EmployeeImage = Path.Combine(all,"EmployeeImage.jpg");
            existingEmployee.PhotoId = Path.Combine(all, "PhotoId.pdf");
            existingEmployee.EducationCredentials = Path.Combine(all, "EducationCredentials.pdf");




            Console.WriteLine("notllskdfjalksjd founs world!");

            await _applicationDbContext.SaveChangesAsync();
        }






    }
}
