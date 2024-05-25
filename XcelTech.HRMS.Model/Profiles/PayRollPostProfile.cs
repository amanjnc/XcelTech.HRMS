﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;

namespace XcelTech.HRMS.Model.Profiles
{
    public class PayRollPostProfile: Profile
    {
        public PayRollPostProfile()
        {

            CreateMap<PayRollPostDto, Payroll>();
        }
    }
}
