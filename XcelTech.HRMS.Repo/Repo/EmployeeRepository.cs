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

        public EmployeeRepository(ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
        }

        public async Task addEmployyetoTable(Employee employee)
        {

            _applicationDbContext.Employees.Add(employee);
            await _applicationDbContext.SaveChangesAsync();
        
        }





        //public async Task updateEmployee(Employee employee)
        //{

        //    Console.WriteLine("this shit!");

        //    var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        //    Console.WriteLine("this shiriririt!");




        //    try
        //    {
        //        var existingEmployee = await _applicationDbContext.Employees.FirstOrDefaultAsync(emp => emp.AppUserId == currentUser.Id);
        //        var savedChanges = await _applicationDbContext.SaveChangesAsync();

        //        //if (existingEmployee == null)
        //        //{
        //        //    Console.WriteLine("this shirasdfljasdfjlasdjflkasjfdiririt!");

        //        //    throw new Exception("Employee not found.");
        //        //}
        //        //Console.WriteLine("this shirasdfljasdasdfkjasdlkfjaslkdfjalksdfjalksdjflkasjdflkasjdflaksjdflkfjlasdjflkasjfdiririt!");


        //        //// Update the existing employee object with values from the input employee object
        //        //foreach (var property in typeof(Employee).GetProperties())
        //        //{
        //        //    var inputValue = property.GetValue(employee);
        //        //    if (inputValue != null)
        //        //    {
        //        //        property.SetValue(existingEmployee, inputValue);
        //        //    }
        //        //}
        //        //Console.WriteLine("shirasdfljasdfjlasdjflkasjfdiririt!");

        //        Console.WriteLine("fjl!");

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("fjdkfjsl!");

        //        // Handle the exception appropriately
        //        Console.WriteLine("An error occurred while updating the employee: " + ex.Message);
        //    }

        //}

        public async Task updateEmployee(Employee employee,string UserEmail)
        {
            //var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);



          

            var existingEmployee = await _applicationDbContext.Employees.FirstOrDefaultAsync(emp => emp.EmployeeEmail == UserEmail);

            if (existingEmployee == null)
            {
                Console.WriteLine("eail",UserEmail);

                throw new Exception("Employee not found.");
            }

            var employeeType = typeof(Employee);

            var properties = employeeType.GetProperties();

            foreach (var property in properties)
            {
                var inputValue = property.GetValue(employee);
                if (inputValue != null)
                {
                    property.SetValue(existingEmployee, inputValue);
                }
            }
            Console.WriteLine("notllskdfjalksjd founs world!");

            await _applicationDbContext.SaveChangesAsync();
        }









        //public async Task updateEmployee(Employee employee)
        //{


        //    var email = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
        //    var user = await _userManager.FindByEmailAsync(email);

        //    var existingEmployee = await _applicationDbContext.Employees.FirstOrDefaultAsync(emp => emp.AppUserId == user.Id);


        //    if (existingEmployee == null)
        //    {
        //        throw new Exception("Employee not found."); 
        //    }


        //    existingEmployee.EmployeeImage = employee.EmployeeImage;

        //    await _applicationDbContext.SaveChangesAsync();



        //    throw new NotImplementedException();
        //}



    }
}
