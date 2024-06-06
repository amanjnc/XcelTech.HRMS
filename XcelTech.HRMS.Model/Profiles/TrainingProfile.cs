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
    public class TrainingProfile : Profile
    {
        public TrainingProfile()
        {
            CreateMap<Training, TrainingDto>().ReverseMap();
        }
    }
}

