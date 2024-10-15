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
using System.Xml;

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
        private readonly IValidator<PasswordDto> _validator3;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;
        private readonly ICacheService _cacheService;
        private readonly IAutoGenerateId _autoGenerateId;
        private readonly UserManager<AppUser> _userManager;

        public RegisterService(UserManager<AppUser> userManager,ICacheService cacheService,IEmailsender emailsender,IAutoGenerateId autoGenerateId, IEmailService emailService,IDepartmentRepository departmentRepository, IEmployeeRepository employeeRepository, IAccountRegister accountRegister, IMapper mapper, IValidator<ProfileInfoDto> validator, IValidator<DtoRegister> validator2, IValidator<PasswordDto> validator3, ITokenService tokenService, IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _validator3 = validator3;
            _cacheService = cacheService;
            _autoGenerateId = autoGenerateId;
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

                var CreatedUser = await _accountRegister.createAdminWithPassword(appUser, dtoRegister.Password);

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
                //employee.PhotoId = Path.Cobine(all, "PhotoId.jpg");

                employee.DepartmentId = departmentId.Value;


                //var AUTOGENERATED_PASSWORD = _autoGeneratePassword.GenerateRandomPassword();
                //Console.WriteLine(AUTOGENERATED_PASSWORD);



                //string emailTemplatePath = Path.Combine(projectDirectory, "XcelTech.HRMS.Helper", "EmailTemplate.cshtml");
                //Console.WriteLine(emailTemplatePath);



                //now 3 diffrent email service 2 fuent (1 html temp)
                var ReceiverEmail = profileInfoDto.EmployeeEmail;
                var EmailTitle = "LOGIN TO YOUR XCELTECH ACCOUNT";
                //var emailBody = EmailBody.GetEmailBody(AUTOGENERATED_PASSWORD);
                //EmailFormatData emailFormatData = new(ReceiverEmail, EmailTitle,emailBody);


                EmailFormatData emailFormatData = new(ReceiverEmail, EmailTitle);
                //await _emailService.SendEmail(emailFormatData);

                string currentDirectory = Directory.GetCurrentDirectory();
                string parentDirectory = Path.GetDirectoryName(currentDirectory);

                string EmailTemplatePath = Path.Combine(parentDirectory, "XcelTech.HRMS.Helper/EmailTemplate.html");
                Console.WriteLine(EmailTemplatePath);


                //_emailsender.SendEmail(ReceiverEmail, AUTOGENERATED_PASSWORD);

                //var createdUser = await _accountRegister.createUser(appUser, AUTOGENERATED_PASSWORD, employee);
                var createdUser = await _accountRegister.createUser(appUser);

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
                        //_emailService.sendEmailAsHtmlTemplate(emailFormatData, profileInfoDto, EmailTemplatePath);


                        await _employeeRepository.addEmployyetoTable(employee);
                        int employeeId = await _employeeRepository.GetEmployeeId(newUserDto.EmployeeEmail);
                        //var AUTOGENERATED_PASSWORD = _autoGeneratePassword.GenerateRandomPassword();

                        var uniqueId = _autoGenerateId.GenerateUniqueId();
                        profileInfoDto.UniqueIdentifier = uniqueId ;
                        
                        _emailService.sendEmailAsHtmlTemplate(emailFormatData, profileInfoDto, EmailTemplatePath);


                        //var uniqueId = "sfasfdasdfsadkjjkkjkjk";
                        var expirationTime = DateTimeOffset.Now.AddMinutes(20.0);

                        var redisValueObject = new ReddisUniqueTokenWithUserIdDto
                        {
                            EmployeeId = employeeId,
                            AppUserId = appUser.Id,
                            PasswordResetToken = uniqueId,
                            Email = newUserDto.EmployeeEmail
                        };



                        var isCached = _cacheService.SetData<ReddisUniqueTokenWithUserIdDto>(uniqueId, redisValueObject, expirationTime);
                        profileInfoDto.UniqueIdentifier = uniqueId;



                        return new OkObjectResult(redisValueObject);
                        //return new OkObjectResult(newUserDto);
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

        public async Task<IActionResult> setPasswordForExistingUser(PasswordDto passwordDto, string appUserId)
        {
            var fluentValidationResult = await _validator3.ValidateAsync(passwordDto);

            if (!fluentValidationResult.IsValid)

            {
                var validationErrors = new List<string>();
                foreach (var error in fluentValidationResult.Errors)
                {
                    validationErrors.Add($"{error.PropertyName}: {error.ErrorMessage}");
                }
                return new BadRequestObjectResult(validationErrors);
            }

            var result = await _accountRegister.setPasswordForExistingUser(passwordDto, appUserId);
            if (result.Succeeded)
            {
                return new OkObjectResult(appUserId);
            }
            else
            {
                return new BadRequestObjectResult(result.Errors.Select(e => e.Description));
            }



        }

        public async Task<IActionResult> resetEmail(ProfileInfoDto profileInfoDto)
        {
            var ReceiverEmail = profileInfoDto.EmployeeEmail;

            var user = await _userManager.FindByEmailAsync(ReceiverEmail);
            if (user == null)
            {
                return new BadRequestObjectResult(new { error = "User not found" });
            }
            var appUserId = user.Id;

            var EmailTitle = "RESET YOUR XCELTECH PASSWORD";

            EmailFormatData emailFormatData = new(ReceiverEmail, EmailTitle);

            string currentDirectory = Directory.GetCurrentDirectory();
            string parentDirectory = Path.GetDirectoryName(currentDirectory);

            string EmailTemplatePath = Path.Combine(parentDirectory, "XcelTech.HRMS.Helper/ResetEmailTemplate.html");
            Console.WriteLine(EmailTemplatePath);

            var uniqueId = _autoGenerateId.GenerateUniqueId();
            profileInfoDto.UniqueIdentifier = uniqueId;

            _emailService.sendEmailAsHtmlTemplate(emailFormatData, profileInfoDto, EmailTemplatePath);
            var expirationTime = DateTimeOffset.Now.AddMinutes(20.0);

            var redisValueObject = new ReddisUniqueTokenWithUserIdDto
            {

                PasswordResetToken = uniqueId,
                Email = profileInfoDto.EmployeeEmail,
                AppUserId = appUserId

            };



            var isCached = _cacheService.SetData<ReddisUniqueTokenWithUserIdDto>(uniqueId, redisValueObject, expirationTime);
            profileInfoDto.UniqueIdentifier = uniqueId;

            return new OkObjectResult(redisValueObject);
            //return new OkObjectResult(new { message = "Email sent successfully" });

        }


        private string GetIdentityErrorMessage(IEnumerable<IdentityError> errors)
        {
            return string.Join(", ", errors.Select(e => e.Description));
        }



      
    
        
    }
}