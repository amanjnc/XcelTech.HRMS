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
    public class EmployeeGet : Profile

    {
        public EmployeeGet()
        {

            CreateMap<Employee, EmployeeGetDto>();
        }
    }
}

