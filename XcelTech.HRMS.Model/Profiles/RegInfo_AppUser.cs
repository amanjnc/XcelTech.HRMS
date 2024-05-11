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
    public class RegInfo_AppUser : Profile
    {

        public RegInfo_AppUser()
        {
            CreateMap<ProfileInfoDto, AppUser>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.EmployeeEmail))
            .ForMember(det => det.UserName, opt => opt.MapFrom(src => src.EmployeeFirstName));


            CreateMap<DtoRegister, AppUser>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.EmployeeEmail))
            .ForMember(det => det.UserName, opt => opt.MapFrom(src => src.EmployeeName));
        }




    }
}
