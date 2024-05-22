using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo.IRepo;

namespace XcelTech.HRMS.Repo.Repo
{
    public class PayRollRepository : IPayRollRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PayRollRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task createPayroll(Payroll payroll)
        {
                var employeeExists = await _applicationDbContext.Employees.AnyAsync(e => e.EmployeeId == payroll.EmployeeId);

    if (!employeeExists)
    {
        // If the EmployeeId doesn't exist, handle the situation
        throw new ArgumentException("EmployeeId does not exist.", nameof(payroll.EmployeeId));
    }

            _applicationDbContext.Payrolls.Add(payroll);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<List<Payroll>> getAllPayRolls()
        {
            var payrolls = await _applicationDbContext.Payrolls.ToListAsync();

            return payrolls;
        }

        public async Task<string> GetEmployeeFullNameByIdAsync(int employeeId)
        {
            // Retrieve the employee from the database using the provided employeeId
            var employee = await _applicationDbContext.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

            // If employee is not found, throw an exception
            if (employee == null)
            {
                throw new ArgumentException("Employee not found.", nameof(employeeId));
            }

            // Combine the first and last name properties into a single string
            string fullName = $"{employee.EmployeeFirstName} {employee.EmployeeLastName}";

            return fullName;
        }
    }
}
