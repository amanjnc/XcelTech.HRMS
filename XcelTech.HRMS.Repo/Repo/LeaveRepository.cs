using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Dto;
using Microsoft.EntityFrameworkCore;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo.IRepo;
using Microsoft.AspNetCore.Mvc;

namespace XcelTech.HRMS.Repo.Repo
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public LeaveRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            
        }
        public async Task addLeaveToTable(Leave leave, string email)
        {
            var CurrentEmployee = await _applicationDbContext.Employees.FirstOrDefaultAsync(emp => emp.EmployeeEmail == email);

            leave.EmployeeId = CurrentEmployee.EmployeeId;
            _applicationDbContext.Leaves.Add(leave);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<List<Leave>> GetAllLeaves()
        {
            var leaves = await _applicationDbContext.Leaves.ToListAsync();

            return leaves;
        }

        public async Task UpdateLeaveStatus(int leaveId, string Status)
        {
            var leave = await _applicationDbContext.Leaves.FirstOrDefaultAsync(l => l.LeaveId == leaveId);
          
            leave.status = Status;
           await _applicationDbContext.SaveChangesAsync();

        }
    }
}
