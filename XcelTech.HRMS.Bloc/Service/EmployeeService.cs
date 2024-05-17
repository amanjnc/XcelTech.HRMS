using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using XcelTech.HRMS.Bloc.IService;
using System.IdentityModel.Tokens.Jwt;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo.IRepo;
using System.Security.Claims;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using XcelTech.HRMS.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace XcelTech.HRMS.Bloc.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ITokenService _tokenService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _applicationDbContext;
        UserManager<AppUser> _userManager;
        private readonly ILeaveRepository _leaveRepository;
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IEmployeeRepository _employeeRepository;
        //private readonly IValidator<ProfileInfoDto> _validator;
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeeService(ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor, ITokenService tokenService, IEmployeeRepository employeeRepository, IMapper mapper, IDepartmentRepository departmentRepository, IWebHostEnvironment webHostEnvironment, UserManager<AppUser> userManager
            , IAttendanceRepository attendanceRepository, ILeaveRepository leaveRepository)
        {
            _leaveRepository = leaveRepository;
            _attendanceRepository = attendanceRepository;
            _applicationDbContext = applicationDbContext;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _tokenService = tokenService;
            _departmentRepository = departmentRepository;
            _mapper = mapper;
            _userManager = userManager;
            _employeeRepository = employeeRepository;

        }



        public async Task<List<EmployeeGetDto>> getAllEmployeesAsync()
        {

            var employees = await _employeeRepository.GetAllEmployeesAsync();
            var employeeGetDtos = _mapper.Map<List<EmployeeGetDto>>(employees);
            return employeeGetDtos;
        }


        public async Task<IActionResult> addEmployee(Employee employee)
        {
            //var CreatedUser = await _accountRegister.createUser(appUser, dtoRegister.Password, employee);
            await _employeeRepository.addEmployyetoTable(employee);

            return new OkObjectResult(employee);




        }

        public async Task<IActionResult> getAllEmployee()
        {
            throw new NotImplementedException();
        }




        //[JsonIgnore]
        //public ExecutionContext Context { get; set; }


        public async Task<IActionResult> updateEmployee(ProfileInfoDto profileInfoDto, string email)
        {


            if (email == null)
            {
                Console.WriteLine("You have failed this coty this shit hurts");
                // Token validation failed or user not found
                return new UnauthorizedResult();
            }

            var department = _mapper.Map<Department>(profileInfoDto);
            var employee = _mapper.Map<Employee>(profileInfoDto);
            // i am fetching dep_Id



            var departmentName = department.DepartmentName;
            var departmentId = await _departmentRepository.getDepartmentByName(departmentName);
            if (departmentId == null)
            {
                Console.WriteLine("not founsdfjaslkdfslkdfjalkfdjalksdf world!");

                return new NotFoundObjectResult("Department not found");
            }
            Console.WriteLine(" world!");


            employee.DepartmentId = departmentId.Value;
            //updating employeetable


            var all = _webHostEnvironment.WebRootPath + "\\Images\\" + email;


            employee.EmployeeImage = Path.Combine(all, "EmployeeImage.jpg");
            employee.EducationCredentials = Path.Combine(all, "EducationCredentials.pdf");


            Console.WriteLine("this shit!");

            await _employeeRepository.updateEmployee(employee, email);
            Console.WriteLine("ld!");

            return new OkResult();


        }

        public async Task<IActionResult> deleteEmployeeUserByEmail(string email)
        {
            try
            {
                var toBeDeletedUser = await _userManager.FindByEmailAsync(email);
                Console.WriteLine("fakkkkkkkkkkke");
                Console.WriteLine(toBeDeletedUser);
                if (toBeDeletedUser == null)
                {
                    return new NotFoundObjectResult($"User with email '{email}' not found.");
                }

                var userId = toBeDeletedUser.Id;

                await _userManager.DeleteAsync(toBeDeletedUser);
                Console.WriteLine("shwws");
                return new OkObjectResult("User, employee, and attendance records deleted successfully.");



                //// Fetch the employee
                //var employee = await _employeeRepository.GetEmployeeByAppUserIdAsync(userId);
                //if (employee == null)
                //{
                //    return new NotFoundObjectResult($"Employee with AppUserId '{userId}' not found.");
                //}

                //// Delete the employee

                //// Delete the attendances
                //var attendances = await _attendanceRepository.GetAttendanceByEmployeeId(employee.EmployeeId);

                //if (!attendances.Any())
                //{
                //    return new NoContentResult();
                //}

                //foreach (var attendance in attendances)
                //{
                //    await _attendanceRepository.DeleteAttendance(attendance);
                //}
                //await _employeeRepository.DeleteEmployee(employee);
                 
                //await _userManager.DeleteAsync(toBeDeletedUser);

                //// Return a successful response
                //return new OkObjectResult("User, employee, and attendance records deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("not sheesh");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
 }
