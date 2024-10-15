using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Dto;
using Microsoft.EntityFrameworkCore;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo.IRepo;
using XcelTech.HRMS.Model;

namespace XcelTech.HRMS.Repo.Repo
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public AttendanceRepository(ApplicationDbContext applicationDbContext) {
            _applicationDbContext= applicationDbContext;
        }
        public async Task AddAttendance(Attendance attendance, string email)
        {
            var CurrentEmployee = await _applicationDbContext.Employees.FirstOrDefaultAsync(emp => emp.EmployeeEmail == email);
            if (CurrentEmployee == null) {
                throw new Exception("Employee not found.");
            }

            attendance.EmployeeId = CurrentEmployee.EmployeeId;
            
            _applicationDbContext.Attendances.Add(attendance);
            await _applicationDbContext.SaveChangesAsync();
        }

        public Task<List<AttendanceDto>> GetTodaysAttendance()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Attendance>> GetAttendanceByEmployeeId(int employeeId)
        {
            try
            {
              
             return await _applicationDbContext.Attendances
                .Where(a => a.EmployeeId == employeeId)
                .Include(a => a.employee)
                .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching attendance by employeeId: {ex.Message}");
            }
        }
        public async Task<bool> DeleteAttendance(Attendance attendance)
        {
            try
            {
                _applicationDbContext.Attendances.Remove(attendance);
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting attendance: {ex.Message}");
            }
        }

    }
}
