using System;
using XcelTech.HRMS.Model.Model;
using AutoMapper;

namespace XcelTech.HRMS.Model.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {

            CreateMap<AppUser, Employee>()
            .ForMember(dest => dest.AppUserId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.EmployeeEmail, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.UserName));




        }

    }
}
