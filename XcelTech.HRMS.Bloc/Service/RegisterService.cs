using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Net;
using System.Text;
using XcelTech.HRMS.Bloc.IService;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo.IRepo;
using XcelTech.HRMS.Repo.Repo;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;
using XcelTech.HRMS.Helper;
using System.Reflection;

namespace XcelTech.HRMS.Bloc.Service
{
    public class RegisterService : IRegisterService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IEmailsender _emailsender;
        private readonly IAccountRegister _accountRegister;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<ProfileInfoDto> _validator;
        private readonly IValidator<DtoRegister> _validator2;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;
        private readonly IAutoGeneratePassword _autoGeneratePassword;
        //string EmailTemplate = "../../XcelTech.HRMS.Helper/EmailTemplate.cshtml";
        


        public RegisterService(IEmailsender emailsender,IAutoGeneratePassword autoGeneratePassword, IEmailService emailService,IDepartmentRepository departmentRepository, IEmployeeRepository employeeRepository, IAccountRegister accountRegister, IMapper mapper, IValidator<ProfileInfoDto> validator, IValidator<DtoRegister> validator2, ITokenService tokenService, IWebHostEnvironment webHostEnvironment)
        {
            _autoGeneratePassword = autoGeneratePassword;
            _emailService = emailService;
            _emailsender = emailsender;
            _employeeRepository = employeeRepository;
            _accountRegister = accountRegister;
            _mapper = mapper;
            _validator = validator;
            _tokenService = tokenService;
            _departmentRepository = departmentRepository;
            _webHostEnvironment = webHostEnvironment;
            _validator2 = validator2;
        }

        public async Task<IActionResult> CreateAdmin(DtoRegister dtoRegister)
        {
            try
            {
                var fluentValidationResult = await _validator2.ValidateAsync(dtoRegister);

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
                    var userRole = "admin";
                    var roleName = userRole;
                    var roleResult = await _accountRegister.createRole(appUser, userRole);

                    if (roleResult.Succeeded)
                    {


                        //converting to strigin, i know so dummmmmmb
                        //var tokenHandler = new JwtSecurityTokenHandler();
                        //var token = tokenHandler.CreateToken(tokennDescriptor);
                        //var token = tokenHandler.WriteToken(tokenn);

                        await _employeeRepository.addEmployyetoTable(employee);

                        Console.WriteLine(appUser.UserName);
                        Console.WriteLine(appUser.Email);

                        var newUserDto = new NewUserDto
                        {
                            EmployeeName = appUser.UserName,
                            EmployeeEmail = appUser.Email,
                            Token = await _tokenService.CreateToken(appUser),
                            RoleName = roleName
                        };


                        return new OkObjectResult(newUserDto);
                    }
                    else
                    {
                        var errorMessage = "Failed to add user to the role. Reason: " + GetIdentityErrorMessage(roleResult.Errors);
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


        public async Task<IActionResult> createUser(ProfileInfoDto profileInfoDto)
        {
            try
            {

                var fluentValidationResult = await _validator.ValidateAsync(profileInfoDto);
                if (!fluentValidationResult.IsValid)
                {
                    var validationErrors = new List<string>();
                    foreach (var error in fluentValidationResult.Errors)
                    {
                        validationErrors.Add($"{error.PropertyName}: {error.ErrorMessage}");
                    }
                    return new BadRequestObjectResult(validationErrors);
                }

                var appUser = _mapper.Map<AppUser>(profileInfoDto);
                var employee = _mapper.Map<Employee>(profileInfoDto);
                employee.AppUserId = appUser.Id;

                var departmentId = await _departmentRepository.getDepartmentByName(profileInfoDto.DepartmentName);
                if (departmentId == null) return new NotFoundObjectResult("Department not found");

                //var all = _webHostEnvironment.WebRootPath + "\\Images\\" + profileInfoDto.EmployeeEmail;
                //employee.EmployeeImage = Path.Combine(all, "EmployeeImage.jpg");
                //employee.EducationCredentials = Path.Combine(all, "EducationCredentials.pdf");
                //employee.PhotoId = Path.Combine(all, "PhotoId.jpg");

                employee.DepartmentId = departmentId.Value;


                var AUTOGENERATED_PASSWORD = _autoGeneratePassword.GenerateRandomPassword();
                Console.WriteLine(AUTOGENERATED_PASSWORD);


                string projectDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                Console.WriteLine(projectDirectory);


                string emailTemplatePath = Path.Combine(projectDirectory, "XcelTech.HRMS.Helper", "EmailTemplate.cshtml");
                Console.WriteLine(emailTemplatePath);



                //now 3 diffrent email service 2 fuent (1 html temp)
                var ReceiverEmail = profileInfoDto.EmployeeEmail;
                var EmailTitle = "your xceltech login password";
                var emailBody = EmailBody.GetEmailBody(AUTOGENERATED_PASSWORD);
                EmailFormatData emailFormatData = new(ReceiverEmail, EmailTitle, emailBody);
                //await _emailService.SendEmail(emailFormatData);

                

                await _emailService.sendEmailAsHtmlTemplate(emailFormatData, profileInfoDto, emailTemplatePath);

                //_emailsender.SendEmail(ReceiverEmail, profileInfoDto.Password);



                var createdUser = await _accountRegister.createUser(appUser, AUTOGENERATED_PASSWORD , employee);

                if (createdUser.Succeeded)
                {

                    var userRole = profileInfoDto.adminAssignedRole;
                    var roleName = userRole;
                    var roleResult = await _accountRegister.createRole(appUser, userRole);

                    if (roleResult.Succeeded)
                    {

                        //var tokenHandler = new JwtSecurityTokenHandler();
                        //var tokenString = tokenHandler.WriteToken(token);

                        var newUserDto = new NewUserDto
                        {
                            EmployeeName = appUser.UserName,
                            EmployeeEmail = appUser.Email,
                            Token = await _tokenService.CreateToken(appUser),
                            RoleName = roleName,
                            departmentName = profileInfoDto.DepartmentName

                        };
                        _employeeRepository.addEmployyetoTable(employee);
                        return new OkObjectResult(newUserDto);
                    }
                    else
                    {
                        var errorMessage = "Failed to add user to the role. Reason: " + GetIdentityErrorMessage(roleResult.Errors);
                        throw new Exception(errorMessage);
                    }
                }
                else
                {
                    var errorMessage = "Failed to create user. Reason: " + GetIdentityErrorMessage(createdUser.Errors);
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

    
        
    }
}