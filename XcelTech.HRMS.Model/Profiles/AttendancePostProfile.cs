using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using XcelTech.HRMS.Model.Dto;

namespace XcelTech.HRMS.Model.Profiles
{
    public class AttendancePostProfile:Profile
    {
        public AttendancePostProfile()
        {
            CreateMap<AttendanceDto, Attendance>();
            
        }
    }
}
