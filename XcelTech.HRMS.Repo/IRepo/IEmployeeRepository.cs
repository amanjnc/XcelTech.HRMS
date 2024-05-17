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
        Task updateEmployee(Employee employee,string email);
        public Task<List<Employee>> GetAllEmployeesAsync();
        public Task<Employee> GetEmployeeByAppUserIdAsync(string appUserId);
        public  Task<bool> DeleteEmployee(Employee employee);



    }
}
