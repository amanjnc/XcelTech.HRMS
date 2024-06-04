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
using System.Web.Helpers;

namespace XcelTech.HRMS.Bloc.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ITokenService _tokenService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IAccountRegister _accountRegister;
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
            , IAttendanceRepository attendanceRepository, ILeaveRepository leaveRepository, IAccountRegister accountRegister)
        {
            _accountRegister = accountRegister;
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

            List<EmployeeGetDto> employeeGetDtos = new List<EmployeeGetDto>();
            var employees = await _employeeRepository.GetAllEmployeesAsync();
            foreach(Employee employee in employees)
            {
                var departmentId = employee.DepartmentId;
                Console.WriteLine(departmentId);
                Console.WriteLine("amanuel beyenee");
                var respectiveDepartmentName = await _departmentRepository.getDepartmentNameById(departmentId);
                Console.WriteLine(respectiveDepartmentName);
                Console.WriteLine(respectiveDepartmentName.Value);

                var respectiveEmployeeEmail = employee.EmployeeEmail;
                var user = await _userManager.FindByEmailAsync(respectiveEmployeeEmail);
                var respectiveRole = await _accountRegister.getRoleOfUser(user);
                var employeeGetDto = _mapper.Map<EmployeeGetDto>(employee);
                employeeGetDto.DepartmentName = respectiveDepartmentName.Value;
                employeeGetDto.Role = respectiveRole;
                employeeGetDtos.Add(employeeGetDto);
            }

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


        public async Task<IActionResult> updateEmployee(EmployeeGetDto employeeGetDto)
        {
           
            var employee = _mapper.Map<Employee>(employeeGetDto);
            var employeeID = employee.EmployeeId;
            if (employeeID == 0)
            {
                Console.WriteLine("You have failed this coty this shit hurts");
                return new UnauthorizedResult();
            }
            var departmentName = employeeGetDto.DepartmentName;
            var role = employeeGetDto.Role;
            var constantEmployeeEmail = await _employeeRepository.GetEmployeeEmail(employeeID);
            var user = await _userManager.FindByEmailAsync(constantEmployeeEmail);
            var respectiveRole = await _accountRegister.getRoleOfUser(user);
            var currentRole = await  _accountRegister.getRoleOfUser(user);

            //there is await dumb urge to remove before adding or else you will just have 2 roles
            await _userManager.RemoveFromRoleAsync(user, currentRole);
            await _userManager.AddToRoleAsync(user, role);


            var departmentID = await _departmentRepository.getDepartmentByName(departmentName);
            var DepartmentID = departmentID.Value;
            if (DepartmentID == 0)
            {
                Console.WriteLine("not founsdfjaslkdfslkdfjalkfdjalksdf world!");

                return new NotFoundObjectResult("Department not found");
            }
            employee.DepartmentId = DepartmentID;
            _employeeRepository.updateEmployee(employee);


            Console.WriteLine(" world!");

            await _employeeRepository.updateEmployee(employee);

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
