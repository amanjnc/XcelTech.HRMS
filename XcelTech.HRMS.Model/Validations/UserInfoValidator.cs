using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;

namespace XcelTech.HRMS.Model.Validations
{
    public class UserInfoValidator : AbstractValidator<AppUser>
    {
        private readonly UserManager<AppUser> _userManager;


        public UserInfoValidator(UserManager<AppUser> userManager)
        {
            _userManager = userManager;



            RuleFor(UI => UI.Email).NotEmpty().WithMessage("please Enter Email")
                .EmailAddress().WithMessage("invalid email format")
                .MustAsync(IsUniqueEmail).WithMessage("Email already Exists, use a different one");




            RuleFor(UI => UI.UserName).NotEmpty().WithMessage("please Enter  Name").
                Length(1, 20).WithMessage("name length should be between  1 and 20");
            //RuleFor(UI => UI.Password).NotEmpty().
            //   MinimumLength(8).Matches("[A-Z]").WithMessage("password must contain at least 1 capital letter");


        }

        private async Task<bool> IsUniqueEmail(string Email, CancellationToken token)
        {

            var existingUserWithSameEmail = await _userManager.FindByEmailAsync(Email);
            return existingUserWithSameEmail == null;

            throw new NotImplementedException();
        }

        


    }
}
