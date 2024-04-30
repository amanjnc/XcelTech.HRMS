using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo.IRepo;

namespace XcelTech.HRMS.Repo.Repo
{
    public class EmployeeRepository : IEmployeeRepository
    {


        private readonly ApplicationDbContext _applicationDbContext;

        public EmployeeRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
         }

        public async Task addEmployyetoTable(Employee employee)
        {

            _applicationDbContext.Employees.Add(employee);
            await _applicationDbContext.SaveChangesAsync();
        
        }
    }
}
