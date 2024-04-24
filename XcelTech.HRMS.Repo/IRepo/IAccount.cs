using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;

namespace XcelTech.HRMS.Repo.IRepo
{
    public interface IAccount
    {
        Task<OkObjectResult> createUser (AppUser appUser, string Password);

    }
}
