using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using XcelTech.HRMS.Bloc.IService;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo.IRepo;

namespace XcelTech.HRMS.Bloc.Service
{
    public class RegisterService : IRegisterService
    {
        private readonly IAccountRegister _accountRegister;
        private readonly IMapper _mapper;
        private readonly IValidator<DtoRegister> _validator;

        public RegisterService(IAccountRegister accountRegister, IMapper mapper, IValidator<DtoRegister> validator)
        {
            _accountRegister = accountRegister;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<IActionResult> createUser(DtoRegister dtoRegister)
        {
            try
            {
                var fluentValidationResult = await _validator.ValidateAsync(dtoRegister);
                
                if (!fluentValidationResult.IsValid)

                {
                    var validationErrors = new List<string>();
                    foreach (var error in fluentValidationResult.Errors)
                    {
                        validationErrors.Add($"{error.PropertyName}: {error.ErrorMessage}");
                    }
                    return new BadRequestObjectResult(validationErrors);
                }
                var appUser = _mapper.Map<AppUser>(dtoRegister);
                var employee = _mapper.Map<Employee>(appUser);




                var result = await _accountRegister.createEmployee(appUser, dtoRegister.Password, employee);
                await _accountRegister.addEmployyetoTable(employee);


                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}