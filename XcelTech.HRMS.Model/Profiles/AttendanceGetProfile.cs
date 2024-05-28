using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;

namespace XcelTech.HRMS.Model.Profiles
{
    public class AttendanceGetProfile:Profile
    {
        public AttendanceGetProfile()
        {
            CreateMap<Attendance, AttendanceDto>()
               .ForMember(dest => dest.ClockinTime, opt => opt.MapFrom(src => src.ClockinTime.ToString("HH:mm:ss")))
               .ForMember(dest => dest.ClockoutTime, opt => opt.MapFrom(src => src.ClockoutTime.HasValue ? src.ClockoutTime.Value.ToString("HH:mm:ss") : null))
            .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => $"{src.employee.EmployeeFirstName} {src.employee.EmployeeLastName}"));


        }
    }
}
