using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
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
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<DtoRegister> _validator;
        private readonly ITokeNService _tokenService;


        public RegisterService(IEmployeeRepository employeeRepository,IAccountRegister accountRegister, IMapper mapper, IValidator<DtoRegister> validator, ITokeNService tokenService)
        {
            _employeeRepository = employeeRepository;
            _accountRegister = accountRegister;
            _mapper = mapper;
            _validator = validator;
            _tokenService = tokenService;
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




                var CreatedUser = await _accountRegister.createUser(appUser, dtoRegister.Password, employee);


                if (CreatedUser.Succeeded)
                {


                    var userRole = DetermineUserRoleByEmail(dtoRegister.EmployeeEmail);
                    var roleName =  userRole;


                    var roleResult = await _accountRegister.createRole(appUser, userRole);

                    if (roleResult.Succeeded)
                    {

                        var newUserDto = new NewUserDto
                        {
                            EmployeeName = appUser.UserName,
                            EmployeeEmail = appUser.Email,
                            Token = _tokenService.CreateToken(appUser),
                            RoleName = roleName
                        };

                        await _employeeRepository.addEmployyetoTable(employee);

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
                    var errorMessage = "Failed to create user. Reason: " + GetIdentityErrorMessage(CreatedUser.Errors);
                    throw new Exception(errorMessage);
                }





            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        private string GetIdentityErrorMessage(IEnumerable<IdentityError> errors)
        {
            return string.Join(", ", errors.Select(e => e.Description));
        }

        private string DetermineUserRoleByEmail(string email)
        {
            ///splitin based on the @ and shoosing the 2nd indexed part
            string domain = email.Split('@')[1];

            if (domain == "admin.com")
            {
                return "admin";
            }
            else if (domain == "employee.com")
            {
                return "employee";
            }
            else if (domain == "hr.com")
            {
                return "hr";
            }
            return null;
        }

    }
}