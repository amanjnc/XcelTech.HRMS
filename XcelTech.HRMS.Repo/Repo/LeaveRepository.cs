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
            var leaves = await _applicationDbContext.Leaves.Include(l => l.employee)
                            .ToListAsync();

            return leaves;
        }

        /*public async Task UpdateLeaveStatus(int leaveId, string Status)
        {
            var leave = await _applicationDbContext.Leaves.FirstOrDefaultAsync(l => l.LeaveId == leaveId);
          
            leave.status = Status;
           await _applicationDbContext.SaveChangesAsync();

        }*/

        public async Task<bool> UpdateLeaveStatus(int leaveId, string status)
        {
            var leave = await _applicationDbContext.Leaves.FirstOrDefaultAsync(l => l.LeaveId == leaveId);
            if (leave == null)
            {
                return false;
            }

            leave.status = status;
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }


        public async Task<Leave> GetLeaveByIdAsync(int leaveId)
        {
            return await _applicationDbContext.Leaves.FindAsync(leaveId);
        }

        public async Task<LeaveTypes> GetLeaveTypeByNameAsync(string leaveTypeName)
        {
            return await _applicationDbContext.LeaveTypes.FirstOrDefaultAsync(lt => lt.LeaveTypeName == leaveTypeName);
        }
        public async Task<IEnumerable<Leave>> GetLeavesByEmployeeIdAndTypeAsync(int employeeId, string leaveType)
        {
            return await _applicationDbContext.Leaves
                                 .Where(l => l.EmployeeId == employeeId && l.LeaveType == leaveType && l.status == "Approved")
                                 .ToListAsync();
        }

        public async Task<List<Leave>> GetLeavesByEmployeeIdAndDateRange(int employeeId, DateOnly startDate, DateOnly endDate)
        {
            return await _applicationDbContext.Leaves
                .Where(l => l.EmployeeId == employeeId && l.status == "Approved" && l.StartDate <= endDate && l.EndDate >= startDate)
                .ToListAsync();
        }

        public async Task<Leave> DeleteLeave(int LeaveId)
        {
            var leave = await _applicationDbContext.Leaves.FirstOrDefaultAsync(l => l.LeaveId == LeaveId);
            _applicationDbContext.Leaves.Remove(leave);
            await _applicationDbContext.SaveChangesAsync();
            return leave;
        }
    }
}
