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
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore;

using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

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

        public async Task UpdateAttendance(Attendance attendance, string email)
        {
            var CurrentEmployee = await _applicationDbContext.Employees.FirstOrDefaultAsync(emp => emp.EmployeeEmail == email);
            if (CurrentEmployee == null)
            {
                throw new Exception("Employee not found.");
            }

            attendance.EmployeeId = CurrentEmployee.EmployeeId;

            _applicationDbContext.Attendances.Update(attendance);
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


        public async Task<List<Attendance>> GetAllAttendances()
        {
            var attendances = await _applicationDbContext.Attendances.Include(l => l.employee)
                            .ToListAsync();

            return attendances;
        }

        public async Task<Attendance> GetAttendanceByEmployeeEmail(string email, DateTime Clockout)
        {
            try
            {
                var employee = await _applicationDbContext.Employees.FirstOrDefaultAsync(emp => emp.EmployeeEmail == email);
                var employeeId = employee.EmployeeId;
                var attendance = await _applicationDbContext.Attendances.FirstOrDefaultAsync(a => a.EmployeeId == employeeId && a.ClockinTime.Date == Clockout.Date);
                return attendance;



            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching attendance by employeeemail: {ex.Message}");
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

        public async Task DeleteAllAttendances()
        {
            _applicationDbContext.Attendances.RemoveRange(_applicationDbContext.Attendances);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteAttendancesByEmployeeId(int employeeId)
        {
            var attendances = _applicationDbContext.Attendances.Where(a => a.EmployeeId == employeeId);
            _applicationDbContext.Attendances.RemoveRange(attendances);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<List<Attendance>> GetAttendancesByEmployeeIdAndDateRange(int EmployeeId, DateOnly startDate, DateOnly endDate)
        {
           /* if (EmployeeId <= 0)
            {
                throw new ArgumentException($"{nameof(EmployeeId)} cannot be 0 or negative.");
            }

            if (startDate > endDate)
            {
                throw new ArgumentException($"{nameof(startDate)} cannot be greater than {nameof(endDate)}.");
            }*/

            
                return await _applicationDbContext.Attendances
                  .Where(h =>h.EmployeeId == EmployeeId)
                  .ToListAsync();
           // => h.date >= startDate && h.date <= endDate &&



        }

    }
}
