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
        public async Task<IActionResult> AddAttendance(AttendanceDto attendanceDto, string email)
        {
            if (email == null)
            {
                Console.WriteLine("You have failed this coty this shit hurts");
                // Token validation failed or user not found
                return new UnauthorizedResult();
            }
            var attendance = _mapper.Map<Attendance>(attendanceDto);

            await _attendanceRepository.AddAttendance(attendance, email);

            return new OkResult();
        }

        public Task<List<AttendanceDto>> GetAllAttendances()
        {
            throw new NotImplementedException();
        }
    }
}
