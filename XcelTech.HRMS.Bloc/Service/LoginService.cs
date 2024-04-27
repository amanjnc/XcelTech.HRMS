using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using XcelTech.HRMS.Bloc.IService;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo.IRepo;

namespace XcelTech.HRMS.Bloc.Service
{
    public  class  LoginService : ILoginService
    {

        private readonly IAccountRegister _accountRegister;
        private readonly ITokeNService _tokenService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginService( IAccountRegister accountRegister, ITokeNService tokenService, IHttpContextAccessor httpContextAccessor)
        {
            _accountRegister = accountRegister;
            _accountRegister = accountRegister;

            _tokenService = tokenService;

        }
        public async Task<IActionResult> checkPasswordThenSignIn(DtoToLogin login, bool rememberMe = false)
        {


            var user = await _accountRegister.checkOnlyEmail(login);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid Email");
            }
        

        var loginResult  =  await _accountRegister.checkPasswordThenSignIn(user , login  , rememberMe);


            if (!loginResult.Succeeded)
            {
                throw new UnauthorizedAccessException("Password incorrect");
            }

            await _accountRegister.finalSignIN(user, rememberMe);



            //var authCookie = Request.Cookies[".AspNetCore.Identity.Application"];
            //Console.WriteLine($"Remember Me Cookie: {authCookie}");

            var newUserDto = new NewUserDto
            {
                EmployeeName = user.UserName,
                EmployeeEmail = user.Email,
                Token = _tokenService.CreateToken(user)
            };


            return new OkObjectResult(newUserDto);



        }
    }
}
