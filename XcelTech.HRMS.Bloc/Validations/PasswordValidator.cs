using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Dto;

namespace XcelTech.HRMS.Bloc.Validations
{
    public class PasswordValidator : AbstractValidator<PasswordDto>
    {

        public PasswordValidator() {
                RuleFor(p => p.Password)
             .NotEmpty().WithMessage("Password cannot be empty.")
        .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
        .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
        .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
        .Matches("[0-9]").WithMessage("Password must contain at least one number.")
        .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");

        }
    }
}
