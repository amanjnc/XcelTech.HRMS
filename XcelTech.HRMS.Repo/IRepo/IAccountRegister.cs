using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace XcelTech.HRMS.Repo.IRepo
{
    public interface IAccountRegister
    {
        Task<IdentityResult> createUser(AppUser appUser, string Password,Employee employee);
        Task<bool> isUniqueEmail(string Email,CancellationToken cancellationToken);
        //Task addEmployyetoTable(Employee employee);
        Task<IdentityResult> createRole(AppUser appUser, string userRole);




        Task<AppUser> checkOnlyEmail(DtoToLogin login);
        Task <SignInResult> checkPasswordThenSignIn(AppUser appUser, DtoToLogin login, bool rememberMe = false);
        Task finalSignIN(AppUser appUser,bool RememberMe);

    }
}
