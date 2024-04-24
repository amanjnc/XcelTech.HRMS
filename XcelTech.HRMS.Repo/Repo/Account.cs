using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using XcelTech.HRMS.Bloc;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo.IRepo;

namespace XcelTech.HRMS.Repo.Repo
{
    public class Account : IAccount
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokeNService _tokenService;

        public Account(ApplicationDbContext applicationDbContext, ITokeNService tokeNService, UserManager<AppUser> userManager)
        {
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
            _tokenService = tokeNService;
        }

        public async Task<OkObjectResult> createUser(AppUser appUser, string Password)
        {
            var createdUser = await _userManager.CreateAsync(appUser, Password);

            if (createdUser.Succeeded)
            {
                if (false)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "buyer");
                    if (roleResult.Succeeded)
                    {
                        var newUserDto = new NewUserDto
                        {
                            EmployeeName = appUser.UserName,
                            EmployeeEmail = appUser.Email,
                            Token = _tokenService.CreateToken(appUser)
                        };

                        return new OkObjectResult(newUserDto);
                    }
                    else
                    {
                        throw new Exception("Failed to add user to the buyer role.");
                    }
                }
                else
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "seller");
                    if (roleResult.Succeeded)
                    {
                        var newUserDto = new NewUserDto
                        {
                            EmployeeName = appUser.UserName,
                            EmployeeEmail = appUser.Email,
                            Token = _tokenService.CreateToken(appUser)
                        };

                        return new OkObjectResult(newUserDto);
                    }
                    else
                    {
                        throw new Exception("Failed to add user to the seller role.");
                    }
                }
            }
            else
            {
                throw new Exception("Failed to create user.");
            }
        }
    }
}





//using Microsoft.AspNetCore.Identity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using XcelTech.HRMS.Model.Model;
//using XcelTech.HRMS.Repo.IRepo;
//using Microsoft.AspNetCore.Mvc;

//using XcelTech.HRMS.Model.Dto;
//using XcelTech.HRMS.Bloc;

//namespace XcelTech.HRMS.Repo.Repo
//{
//    public class Account : IAccount
//    {
//        private readonly ApplicationDbContext _applicationDbContext;
//        private readonly UserManager<AppUser> _userManager;
//        private readonly ITokeNService _tokenService;


//        public Account(ApplicationDbContext applicationDbContext, ITokeNService tokeNService,UserManager<AppUser> userManager)

//        {
//            _applicationDbContext = applicationDbContext;
//            _userManager = userManager;
//            _tokenService = tokeNService;   
//        }


//        public async Task<IActionResult> createUser(AppUser appUser, string Password)
//        {
//            var createdUser = await _userManager.CreateAsync(appUser, Password);

//            if (createdUser.Succeeded)
//            {
//                if (false)
//                {
//                    var roleResult = await _userManager.AddToRoleAsync(appUser, "buyer");
//                    if (roleResult.Succeeded)
//                    {
//                        var newUserDto = new NewUserDto
//                        {
//                            EmployeeName = appUser.UserName,
//                            EmployeeEmail = appUser.Email,
//                            Token = _tokenService.CreateToken(appUser)

//                            //Token = _tokenService.CreateToken(appUser)
//                        };

//                        return ok(newUserDto);
//                    }
//                    else
//                    {
//                        throw new Exception("Failed to add user to the buyer role.");
//                    }
//                }
//                else
//                {
//                    var roleResult = await _userManager.AddToRoleAsync(appUser, "seller");
//                    if (roleResult.Succeeded)
//                    {
//                        var newUserDto = new NewUserDto
//                        {
//                            EmployeeName = appUser.UserName,
//                            EmployeeEmail = appUser.Email,
//                            Token = _tokenService.CreateToken(appUser)

//                            //Token = _tokenService.CreateToken(appUser)
//                        };

//                        return ok(newUserDto);
//                    }
//                    else
//                    {
//                        throw new Exception("Failed to add user to the seller role.");
//                    }
//                }
//            }
//            else
//            {
//                throw new Exception("Failed to create user.");
//            }
//        }
//    }
//}