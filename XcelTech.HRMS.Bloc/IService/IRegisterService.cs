﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Dto;

namespace XcelTech.HRMS.Bloc.IService
{
    public interface IRegisterService
    {
        Task<IActionResult>  createUser(ProfileInfoDto profileInfoDto);
    }
}
