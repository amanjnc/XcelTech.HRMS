using FluentValidation;
using XcelTech.HRMS.Bloc.IService;
using XcelTech.HRMS.Bloc.Service;
using XcelTech.HRMS.Bloc.Validations;
using XcelTech.HRMS.Bloc;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo.IRepo;
using XcelTech.HRMS.Repo.Repo;

namespace XcelTech.HRMS.Api.Extensions
{
    public static class ServiceRegistrations
    {
        public static void RegisterScopedServices(IServiceCollection services)
        {
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IFilehandleService, FileHandleService>();
            services.AddScoped<ILeaveRepository, LeaveRepository>();
            services.AddScoped<ILeaveService, LeaveService>();
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            services.AddScoped<IAttendanceService, AttendanceService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IAccountRegister, AccountRegister>();
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<IValidator<DtoRegister>, UserInfoValidator>();
            services.AddScoped<IValidator<ProfileInfoDto>, ProfileInfoDtoValidator>();
            services.AddScoped<IValidator<Department>, DepartmentValidator>();
            services.AddScoped<ITokenService, TokenService>();


        }
    }
}
