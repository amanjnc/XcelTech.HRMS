using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo.IRepo;

namespace XcelTech.HRMS.Bloc.Validations
{
    
    public class DepartmentValidator : AbstractValidator<Department>
    {
       
        public DepartmentValidator()
        {
            RuleFor(dep => dep.DepartmentName).NotEmpty().WithMessage("please enter department name")
                .Length(2, 30).WithMessage(("name length should be between  2 and 30 "));
            RuleFor(dep => dep.DepartmentDescription).NotEmpty().WithMessage("descirption can not be empty")
                .Length(10, 100).WithMessage(("description should be between  10 and 100 words"));



        }
    }
}



