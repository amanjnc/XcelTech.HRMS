using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.IdentityModel.Tokens.Jwt;
using XcelTech.HRMS.Bloc.IService;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo.IRepo;
using XcelTech.HRMS.Repo.Repo;

namespace XcelTech.HRMS.Bloc.Service
{
    public class RegisterService : IRegisterService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IAccountRegister _accountRegister;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<DtoRegister> _validator;
        private readonly ITokenService _tokenService;


        public RegisterService(IDepartmentRepository departmentRepository, IEmployeeRepository employeeRepository,IAccountRegister accountRegister, IMapper mapper, IValidator<DtoRegister> validator, ITokenService tokenService, IWebHostEnvironment webHostEnvironment)
        {
            _employeeRepository = employeeRepository;
            _accountRegister = accountRegister;
            _mapper = mapper;
            _validator = validator;
            _tokenService = tokenService;
            _departmentRepository = departmentRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        //public async Task<IActionResult> createUser(DtoRegister dtoRegister)
        //{
        //    try
        //    {
        //        var fluentValidationResult = await _validator.ValidateAsync(dtoRegister);

        //        if (!fluentValidationResult.IsValid)

        //        {
        //            var validationErrors = new List<string>();
        //            foreach (var error in fluentValidationResult.Errors)
        //            {
        //                validationErrors.Add($"{error.PropertyName}: {error.ErrorMessage}");
        //            }
        //            return new BadRequestObjectResult(validationErrors);
        //        }
        //        var appUser = _mapper.Map<AppUser>(dtoRegister);
        //        var employee = _mapper.Map<Employee>(appUser);




        //        var CreatedUser = await _accountRegister.createUser(appUser, dtoRegister.Password, employee);


        //        if (CreatedUser.Succeeded)
        //        {


        //            var userRole = DetermineUserRoleByEmail(dtoRegister.EmployeeEmail);
        //            var roleName =  userRole;


        //            var roleResult = await _accountRegister.createRole(appUser, userRole);

        //            if (roleResult.Succeeded)
        //            {
        //                var tokenn = _tokenService.CreateToken(appUser);


        //                //converting to strigin, i know so dummmmmmb
        //                var tokenHandler = new JwtSecurityTokenHandler();
        //                var token = tokenHandler.WriteToken(tokenn);

        //                var newUserDto = new NewUserDto
        //                {
        //                    EmployeeName = appUser.UserName,
        //                    EmployeeEmail = appUser.Email,
        //                    Token = token,
        //                    RoleName = roleName
        //                };

        //                await _employeeRepository.addEmployyetoTable(employee);

        //                return new OkObjectResult(newUserDto);
        //            }
        //            else
        //            {
        //                var errorMessage = "Failed to add user to the role. Reason: " + GetIdentityErrorMessage(roleResult.Errors);
        //                throw new Exception(errorMessage);
        //            }
        //        }
        //        else
        //        {
        //            var errorMessage = "Failed to create user. Reason: " + GetIdentityErrorMessage(CreatedUser.Errors);
        //            throw new Exception(errorMessage);
        //        }





        //    }
        //    catch (Exception ex)
        //    {
        //        return new BadRequestObjectResult(ex.Message);
        //    }
        //}


        public async Task<IActionResult> createUser(ProfileInfoDto profileInfoDto)
        {
            try
            {
                // Perform validation if needed
                // var fluentValidationResult = await _validator.ValidateAsync(dtoRegister);
                // if (!fluentValidationResult.IsValid)
                // {
                //     var validationErrors = new List<string>();
                //     foreach (var error in fluentValidationResult.Errors)
                //     {
                //         validationErrors.Add($"{error.PropertyName}: {error.ErrorMessage}");
                //     }
                //     return new BadRequestObjectResult(validationErrors);
                // }

                // Map profileInfoDto to AppUser and Employee entities
                var appUser = _mapper.Map<AppUser>(profileInfoDto);

                var employee = _mapper.Map<Employee>(profileInfoDto);
                //var employee = _mapper.Map<Employee>(AppUser);

                employee.AppUserId = appUser.Id;
                Console.WriteLine(employee);

                //to write the depId instead of the depName
                var departmentId = await _departmentRepository.getDepartmentByName(profileInfoDto.DepartmentName);
                if (departmentId == null)
                {
                    Console.WriteLine("not founsdfjaslkdfslkdfjalkfdjalksdf world!");

                    return new NotFoundObjectResult("Department not found");
                }
                Console.WriteLine(" world!");
                var all = _webHostEnvironment.WebRootPath + "\\Images\\" + profileInfoDto.EmployeeEmail;


                employee.EmployeeImage = Path.Combine(all, "EmployeeImage.jpg");
                employee.EducationCredentials = Path.Combine(all, "EducationCredentials.pdf");
                employee.PhotoId = Path.Combine(all, "PhotoId.jpg");



                employee.DepartmentId = departmentId.Value;
                Console.WriteLine("departmentId");
                Console.WriteLine(employee.DepartmentId);

                // Handle image file upload
                //if (profileInfoDto.EmployeeImage != null && profileInfoDto.EmployeeImage.Length > 0)
                //{
                //    using (var stream = new MemoryStream())
                //    {
                //        await profileInfoDto.EmployeeImage.CopyToAsync(stream);
                //        employee.EmployeeImage = stream.ToArray();
                //    }
                //}

                //// Handle credential ID file upload
                //if (profileInfoDto.employeeCredentailFile != null && profileInfoDto.employeeCredentailFile.Length > 0)
                //{
                //    using (var stream = new MemoryStream())
                //    {
                //        await profileInfoDto.employeeCredentailFile.CopyToAsync(stream);
                //        employee.employeeCredentailFile = stream.ToArray();
                //    }
                //}

                // Create the user and employee
                var createdUser = await _accountRegister.createUser(appUser, profileInfoDto.Password, employee);

                if (createdUser.Succeeded)
                {
                    var userRole = DetermineUserRoleByEmail(profileInfoDto.EmployeeEmail);
                    var roleName = userRole;

                    var roleResult = await _accountRegister.createRole(appUser, userRole);

                    if (roleResult.Succeeded)
                    {
                        var token = _tokenService.CreateToken(appUser);
                        var tokenHandler = new JwtSecurityTokenHandler();
                        var tokenString = tokenHandler.WriteToken(token);

                        var newUserDto = new NewUserDto
                        {
                            EmployeeName = appUser.UserName,
                            EmployeeEmail = appUser.Email,
                            Token = tokenString,
                            RoleName = roleName,
                            departmentName = profileInfoDto.DepartmentName

                        };
                        Console.WriteLine("gonna addd to employee tableee");
                        _employeeRepository.addEmployyetoTable(employee);
                        Console.WriteLine("asdkfjlsd");
                        Console.WriteLine(employee);
                        return new OkObjectResult(employee);
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