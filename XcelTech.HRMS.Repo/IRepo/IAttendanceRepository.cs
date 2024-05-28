using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;

namespace XcelTech.HRMS.Repo.IRepo
{
    public interface IAttendanceRepository
    {
        Task AddAttendance(Attendance attendance, string email);

        Task <List<AttendanceDto>> GetTodaysAttendance();
        Task<IEnumerable<Attendance>> GetAttendanceByEmployeeId(int employeeId);
        Task<bool> DeleteAttendance(Attendance attendance);

        Task<Attendance> GetAttendanceByEmployeeEmail(string email);

        Task UpdateAttendance(Attendance attendance, string email);

        Task<List<Attendance>> GetAllAttendances();

    }
}
