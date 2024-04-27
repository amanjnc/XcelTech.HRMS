using FluentValidation;
using System;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Repo.IRepo;

namespace XcelTech.HRMS.Bloc.Validations
{
    public class UserInfoValidator : AbstractValidator<DtoRegister>
    {
        private readonly IAccountRegister _accountregister;





        public UserInfoValidator(IAccountRegister accountRegister)
        {
            _accountregister = accountRegister;



            RuleFor(UI => UI.EmployeeEmail).NotEmpty().WithMessage("please Enter Email")
                .EmailAddress().WithMessage("invalid email format")
                .MustAsync(_accountregister.isUniqueEmail).WithMessage("Email already Exists, use a different one");




            RuleFor(UI => UI.EmployeeName).NotEmpty().WithMessage("please Enter  Name").
                Length(1, 20).WithMessage("name length should be between  1 and 20");
            RuleFor(UI => UI.Password).NotEmpty().
               MinimumLength(8).Matches("[A-Z]").WithMessage("password must contain at least 1 capital letter");


        }

    }
}
