using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Dto;

namespace XcelTech.HRMS.Bloc.IService
{
    public interface IAttendanceService
    {
        Task<IActionResult> Clockin(AttendanceClockin _clockinTime , string email);

        Task<IActionResult> Clockout(AttendanceClockin _clockoutTime, string email);

        Task<List<AttendanceDto>> GetTodaysAttendance();

        Task<List<AttendanceDto>> getAllAttendances();

        Task DeleteAllAttendances();
        Task DeleteAttendancesByEmployeeId(int employeeId);
    }
}
