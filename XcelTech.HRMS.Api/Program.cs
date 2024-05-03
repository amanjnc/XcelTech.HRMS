using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Bloc;
using XcelTech.HRMS.Repo;
using XcelTech.HRMS.Repo.IRepo;
using XcelTech.HRMS.Repo.Repo;
using XcelTech.HRMS.Bloc;
using FluentValidation;
using XcelTech.HRMS.Api.Extensions;
using System;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Profiles;
using XcelTech.HRMS.Bloc.Validations;
using XcelTech.HRMS.Bloc.IService;
using XcelTech.HRMS.Bloc.Service;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddControllers();
builder.Services.ConfigureCors();
builder.Services.AddEndpointsApiExplorer();




builder.Services.ConfigureDbContext(builder.Configuration);



builder.Services.ConfigureSwagger();
builder.Services.AddCustomIdentity(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(typeof(RegInfo_AppUser));
builder.Services.AddAutoMapper(typeof(UserProfile));



builder .Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IAccountRegister, AccountRegister>();
builder.Services.AddScoped<IRegisterService, RegisterService>();
builder.Services.AddScoped<IValidator<DtoRegister>, UserInfoValidator>();
builder.Services.AddScoped<IValidator<Department>, DepartmentValidator>();

builder.Services.AddScoped<ITokeNService, TokenService>();


builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.ApplyMigrations();

}



app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapControllers();

app.UseCors("vite");

app.Run();

