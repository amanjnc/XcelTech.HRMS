using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;

namespace XcelTech.HRMS.Model.Profiles
{
    public class ProfileInfoProfile : Profile
    {
        public ProfileInfoProfile()
        {

            CreateMap<ProfileInfoDto, Employee>()
                .ForMember(dest => dest.EmployeeAddress, opt => opt.MapFrom(src => src.EmployeeAddress))
                .ForMember(dest => dest.EmployeeAge, opt => opt.MapFrom(src => src.EmployeeAge));
            CreateMap<ProfileInfoDto, Department>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.DepartmentName));


        }
        // for bothe department and employee
    }
}
