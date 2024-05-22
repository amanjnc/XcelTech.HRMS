using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Repo.IRepo;

namespace XcelTech.HRMS.Bloc.Validations
{


    public class ProfileInfoDtoValidator :AbstractValidator<ProfileInfoDto>
    {
        private readonly IAccountRegister _accountregister;

        public ProfileInfoDtoValidator(IAccountRegister accountregister)
        {
            _accountregister = accountregister;



            RuleFor(p => p.DepartmentName).NotEmpty().WithMessage("please select department name");
            RuleFor(p => p.EmployeeAddress).NotEmpty().WithMessage("please enter a valid address")
                .Length(2, 30).WithMessage(("address length should be between  2 and 30 "));
            RuleFor(p => p.EmployeeEmail).NotEmpty().WithMessage("please Enter Email")
                .EmailAddress().WithMessage("invalid email format")
                .MustAsync(_accountregister.isUniqueEmail).WithMessage("Email already Exists, use a different one");
            RuleFor(p => p.EmployeeFirstName).NotEmpty().WithMessage("please Enter first Name").
                Length(1, 20).WithMessage("name length should be between  1 and 20");
            RuleFor(p => p.EmployeeLastName).NotEmpty().WithMessage("please Enter  last Name").
                Length(1, 20).WithMessage("name length should be between  1 and 20");
            //RuleFor(p => p.Password).NotEmpty().
            //   MinimumLength(8).Matches("[A-Z]").WithMessage("password must contain at least 1 capital letter");

          
            RuleFor(p => p.EmployeePhone)
                .NotEmpty().WithMessage("Please enter a phone number")
                .Matches(@"^\+(?:[0-9] ?){6,14}[0-9]$").WithMessage("Invalid phone number format");
            RuleFor(p => p.Gender)
                .NotNull().WithMessage("Please select a gender");
            RuleFor(p => p.adminAssignedRole)
                .NotNull().WithMessage("Please select a role");
            RuleFor(p => p.DepartmentName)
                .NotNull().WithMessage("Please select a department");
            RuleFor(p => p.EmployeeImage)
                .NotNull().WithMessage("Please add a photo");
            RuleFor(p => p.EducationCredentials)
                .NotNull().WithMessage("Please select add a certificate");
            RuleFor(p => p.PhotoId)
                .NotNull().WithMessage("Please add a photoId");
        }
    }
}
