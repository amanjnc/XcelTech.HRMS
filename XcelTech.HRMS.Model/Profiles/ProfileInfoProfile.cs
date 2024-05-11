using AutoMapper;
using Microsoft.AspNetCore.Http;
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
                .ForMember(dest => dest.EmployeePhone, opt => opt.MapFrom(src => src.EmployeePhone))
                .ForMember(dest => dest.EmployeeLastName, opt => opt.MapFrom(src => src.EmployeeLastName))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                //.ForMember(dest => dest.departmentName, opt => opt.MapFrom(src => src.DepartmentName))
                .ForMember(dest => dest.EmployeeEmail, opt => opt.MapFrom(src => src.EmployeeEmail))
                .ForMember(dest => dest.EmployeeFirstName, opt => opt.MapFrom(src => src.EmployeeFirstName));

            CreateMap<ProfileInfoDto, Department>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.DepartmentName));
        }

        private static byte[] GetByteArrayFromIFormFile(IFormFile file)
        {
            if (file == null)
                return null;

            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                return stream.ToArray();
            }
        }
    }
}