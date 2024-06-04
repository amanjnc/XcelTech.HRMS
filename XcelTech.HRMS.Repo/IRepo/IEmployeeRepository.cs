using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Model;

namespace XcelTech.HRMS.Repo.IRepo
{


    public interface IEmployeeRepository
    {
        Task addEmployyetoTable(Employee employee);
        Task updateEmployee(Employee employee);
        public Task<List<Employee>> GetAllEmployeesAsync();
        public Task<Employee> GetEmployeeByAppUserIdAsync(string appUserId);
        public Task<int> GetEmployeeId(string Email);
        public Task<string> GetEmployeeEmail(int employeeId);
        

        public Task<bool> DeleteEmployee(Employee employee);




    }
}
