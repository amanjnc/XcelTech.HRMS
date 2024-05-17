using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using System.IdentityModel.Tokens.Jwt;
using XcelTech.HRMS.Bloc.IService;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo.IRepo;

namespace XcelTech.HRMS.Bloc.Service
{
    public class LoginService : ILoginService
    {

        private readonly IAccountRegister _accountRegister;
        private readonly ITokenService _tokenService;

        public LoginService(IAccountRegister accountRegister, ITokenService tokenService)
        {
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

            var roleName = await _accountRegister.getRoleOfUser(user);

            var loginResult = await _accountRegister.checkPasswordThenSignIn(user, login, rememberMe);

            if (!loginResult.Succeeded)
            {
                throw new UnauthorizedAccessException("Password incorrect");
            }

            await _accountRegister.finalSignIN(user, rememberMe);

            //var authCookie = Request.Cookies[".AspNetCore.Identity.Application"];
            //Console.WriteLine($"Remember Me Cookie: {authCookie}");

            var tokenn = await _tokenService.CreateToken(user);
            Console.WriteLine(user.UserName);
            Console.WriteLine(user.Email);



            ////converting to strigin, i know so dummmmmmb
            //var tokenHandler = new JwtSecurityTokenHandler();
            //var token = tokenHandler.WriteToken(tokenn);

            var newUserDto = new NewUserDto
            {
                EmployeeName = user.UserName,
                EmployeeEmail = user.Email,
                Token = tokenn,
                //expiration = token.ValidTo,
                RoleName = roleName,
            };


            return new OkObjectResult(newUserDto);



        }
    }
}