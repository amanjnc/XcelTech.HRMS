using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using XcelTech.HRMS.Bloc;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo.IRepo;

namespace XcelTech.HRMS.Repo.Repo
{
    public class Account : IAccount
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokeNService _tokenService;
        private readonly ApplicationDbContext _applicationDbContext;

        public Account(UserManager<AppUser> userManager, ITokeNService tokenService, ApplicationDbContext applicationDbContext)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IActionResult> createUser(AppUser appUser, string password)
        {
            var createdUser = await _userManager.CreateAsync(appUser, password);

            if (createdUser.Succeeded)
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
                    var errorMessage = "Failed to add user to the buyer role. Reason: " + GetIdentityErrorMessage(roleResult.Errors);
                    throw new Exception(errorMessage);
                }
            }
            else
            {
                var errorMessage = "Failed to create user. Reason: " + GetIdentityErrorMessage(createdUser.Errors);
                throw new Exception(errorMessage);
            }
        }

        private string GetIdentityErrorMessage(IEnumerable<IdentityError> errors)
        {
            return string.Join(", ", errors.Select(e => e.Description));
        }
    }
}