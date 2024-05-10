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
using XcelTech.HRMS.Repo;

namespace XcelTech.HRMS.Bloc.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ITokenService _tokenService;

        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IEmployeeRepository _employeeRepository;
        //private readonly IValidator<ProfileInfoDto> _validator;
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeeService(IHttpContextAccessor httpContextAccessor,ITokenService tokenService, IEmployeeRepository employeeRepository, IMapper mapper, IDepartmentRepository departmentRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _tokenService = tokenService;
            _departmentRepository = departmentRepository;
            _mapper = mapper;   
           
            _employeeRepository = employeeRepository;

        }





        public async  Task<IActionResult> addEmployee(Employee employee)
        {
            //var CreatedUser = await _accountRegister.createUser(appUser, dtoRegister.Password, employee);
            await _employeeRepository.addEmployyetoTable(employee);

            return new OkObjectResult(employee);




        }

        [JsonIgnore]
        public ExecutionContext Context { get; set; }


        public async Task<IActionResult> updateEmployee(ProfileInfoDto profileInfoDto,string email,string imagepath)
        {
            // will do validation here
            //var fluentValidationResult = await _validator.ValidateAsync(profileInfoDto);

            //if (!fluentValidationResult.IsValid)

            //{
            //    var validationErrors = new List<string>();
            //    foreach (var error in fluentValidationResult.Errors)
            //    {
            //        validationErrors.Add($"{error.PropertyName}: {error.ErrorMessage}");
            //    }
            //    return new BadRequestObjectResult(validationErrors);
            //}


           
           
            if (email == null)
            {
                Console.WriteLine("You have failed this coty this shit hurts");
                // Token validation failed or user not found
                return new UnauthorizedResult();
            }


           // var config = new MapperConfiguration(cfg =>
            //{
               // cfg.CreateMap<ProfileInfoDto, Employee>()
                    //.ForMember(dest => dest.EmployeeImage, opt => opt.MapFrom(src => ConvertToByteArrayAsync(src.EmployeeImage).Result));
           // });

            //var mapper = config.CreateMapper();

            var department = _mapper.Map<Department>(profileInfoDto);
            var employee = _mapper.Map<Employee>(profileInfoDto);
            //employee.EmployeeImage = imagepath;

            Console.WriteLine(employee.EmployeeImage==null);
            Console.WriteLine(profileInfoDto.EmployeeImage==null);

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

            Console.WriteLine("this shit!");

            await _employeeRepository.updateEmployee(employee,email,imagepath);
            Console.WriteLine("ld!");

            return new OkResult();

            
        }
        private async Task<byte[]> ConvertToByteArrayAsync(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }

       public async Task<Employee> GetEmployeeProfile(string email)
        {
            return await _employeeRepository.GetEmployeeProfile(email);

        }


    }
}
