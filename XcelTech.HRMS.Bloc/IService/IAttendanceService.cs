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
        Task<IActionResult> AddAttendance(AttendanceDto attendanceDto, string email);

        Task<List<AttendanceDto>> GetTodaysAttendance();
    }
}
