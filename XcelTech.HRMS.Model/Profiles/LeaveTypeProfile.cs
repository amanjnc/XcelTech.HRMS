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
    public class LeaveTypeProfile : Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeDto, LeaveTypes>()
                .ForMember(dest => dest.LeavePaymentDetails, opt => opt.MapFrom(src => src.LeavePaymentDetails));

            CreateMap<LeavePaymentDetailDto, LeavePaymentDetail>();

            CreateMap<LeaveTypes, LeaveTypeDto>()
                .ForMember(dest => dest.LeavePaymentDetails, opt => opt.MapFrom(src => src.LeavePaymentDetails));

            CreateMap<LeavePaymentDetail, LeavePaymentDetailDto>();
        }
    }

}
