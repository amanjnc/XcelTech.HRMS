using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Model.Dto;

namespace XcelTech.HRMS.Model.Profiles
{
    public class GetLeaveProfile : Profile
    {
        public GetLeaveProfile()
        {
         CreateMap<Leave, GetLeaveDto>()
         .ForMember(dest => dest.EmployeeEmail, opt => opt.MapFrom(src => src.employee.EmployeeEmail))
         .ForMember(dest => dest.employeeName, opt => opt.MapFrom(src => $"{src.employee.EmployeeFirstName} {src.employee.EmployeeLastName}"));

        }
    }
}
