using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Bloc.IService;
using XcelTech.HRMS.Model;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo.IRepo;
using XcelTech.HRMS.Repo.Repo;

namespace XcelTech.HRMS.Bloc.Service
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IMapper _mapper;
        private readonly IAttendanceRepository _attendanceRepository;
        public AttendanceService(IMapper mapper, IAttendanceRepository attendanceRepository) { 
        _attendanceRepository = attendanceRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Clockin(DateTime _clockinTime, string email)
        {
            if (email == null)
            {
                return new UnauthorizedResult();
            }
            //var attendance = _mapper.Map<Attendance>(attendanceDto);

            var attendance = new Attendance { ClockinTime = _clockinTime };

            await _attendanceRepository.AddAttendance(attendance, email);

            return new OkResult();
        }

        public async Task<IActionResult> Clockout(DateTime _clockoutTime, string email)
        {
            if (email == null)
            {
                return new UnauthorizedResult();
            }
            //var attendance = _mapper.Map<Attendance>(attendanceDto);

            var attendance = await _attendanceRepository.GetAttendanceByEmployeeEmail(email);
            attendance.ClockoutTime = _clockoutTime;


            TimeSpan? Total = attendance.ClockoutTime - attendance.ClockinTime;

            int totalMinutes = (int)Total?.TotalMinutes;

            int hours = totalMinutes / 60;
            int minutes = totalMinutes % 60;

            TimeOnly result = new TimeOnly(hours,minutes);

            attendance.TotalTime = result;

            await _attendanceRepository.UpdateAttendance(attendance, email);

            return new OkResult();
        }

        public async Task<List<AttendanceDto>> getAllAttendances()
        {
            var attendances = await _attendanceRepository.GetAllAttendances();
            var attendanceDtos = _mapper.Map<List<AttendanceDto>>(attendances);

            //var employeeGetDtos = _mapper.Map<List<EmployeeGetDto>>(employees);

            return attendanceDtos;
        }

        public Task<List<AttendanceDto>> GetTodaysAttendance()
        {
            throw new NotImplementedException();
        }
    }
}
