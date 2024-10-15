using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;
using AutoMapper;

namespace XcelTech.HRMS.Model.Profiles
{
    public class LeaveCreateProfile: Profile
    {

        public LeaveCreateProfile()
        {

            CreateMap<LeaveDto,Leave>();

        }
    }
}
