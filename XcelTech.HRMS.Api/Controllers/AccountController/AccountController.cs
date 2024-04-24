﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XcelTech.HRMS.Bloc;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo.IRepo;

namespace XcelTech.HRMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokeNService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IAccount _account;

        public AccountController(UserManager<AppUser> userManager, ITokeNService tokenService, SignInManager<AppUser> signInManager, IAccount account)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _account = account;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] DtoRegister dtoRegister)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var appUser = new AppUser
                {
                    UserName = dtoRegister.EmployeeName,
                    Email = dtoRegister.EmployeeEmail,
                    // since appuser doesn't need the password, it can be initialized without it
                };

                var result = await _account.createUser(appUser, dtoRegister.Password);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]DtoToLogin login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == login.EmployeeEmail.ToLower());
            if (user == null)
            {
                return Unauthorized("Invalid Username");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);

            if (!result.Succeeded)
            {
                return Unauthorized("Username not found or password incorrect");
            }

            return Ok(new NewUserDto
            {
                EmployeeName = user.UserName,
                EmployeeEmail = user.Email,
                Token = _tokenService.CreateToken(user)
            });
        }
    }
}












//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using XcelTech.HRMS.Model.Dto;
//using XcelTech.HRMS.Model.Model;
//using XcelTech.HRMS.Repo.IRepo;

//namespace XcelTech.HRMS.Api.Controllers.AccountController
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AccountController : ControllerBase
//    {

//        private readonly UserManager<AppUser> _userManager;

//        //private readonly ITokenService _tokenService;

//        private readonly SignInManager<AppUser> _signInManager;

//        private readonly IAccount  _Account;


//        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager, IAccount account)
//        {
//            _userManager = userManager;


//            //_tokenService = tokenService;

//            _signInManager = signInManager;

//            _Account = account;

//        }

//        [HttpPost("Register")]
//        public async Task<IActionResult> Register([FromBody] DtoRegister dtoRegister)
//        { 
//            try
//            {
//                if (!ModelState.IsValid) return BadRequest(ModelState);

//                var appUser = new AppUser
//                {
//                    UserName = dtoRegister.EmployeeName,
//                    Email = dtoRegister.EmployeeEmail,
//                    //since appuser  dont need th password inits obj


//                };
//                return await _Account.createUser(appUser, dtoRegister.Password);

//            } catch(Exception ex)

//            {
//                return StatusCode(500, ex.Message);

//            }



//        }



//        }
//}

