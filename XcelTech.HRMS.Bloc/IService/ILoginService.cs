using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;

namespace XcelTech.HRMS.Bloc.IService
{
    public interface ILoginService
    {
        //Task checkOnlyEmail(DtoToLogin login);
        Task<IActionResult> checkPasswordThenSignIn( DtoToLogin login, bool rememberMe =false);
    }
}
