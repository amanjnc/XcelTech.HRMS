using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Repo.IRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace XcelTech.HRMS.Repo.Repo
{
    public class EmployeeFileRepository : IEmployeeFileRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public EmployeeFileRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            
        }
        public async Task CreateEmployeeFile(EmployeeFile employeeFile)
        {

            _applicationDbContext.EmployeeFiles.Add(employeeFile);
            await _applicationDbContext.SaveChangesAsync();
        }
        public async Task<EmployeeFile> DeleteEmployeeFile (int UserId){
            var employeefile = await _applicationDbContext.EmployeeFiles.FirstOrDefaultAsync(l => l.EmployeeId == UserId);
            _applicationDbContext.EmployeeFiles.RemoveRange(employeefile);
            await _applicationDbContext.SaveChangesAsync();
            return employeefile;
        }

        public async Task<EmployeeFile> GetEmployeeFile(int UserId)
        {
            var employeefile = await _applicationDbContext.EmployeeFiles.FirstOrDefaultAsync(l => l.EmployeeId == UserId);

            return employeefile;
        }


    }
}
