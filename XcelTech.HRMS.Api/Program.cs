using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo;
using XcelTech.HRMS.Repo.IRepo;
using XcelTech.HRMS.Repo.Repo;
using FluentValidation;
using XcelTech.HRMS.Api.Extensions;
using System;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Profiles;
using XcelTech.HRMS.Bloc.Validations;
using XcelTech.HRMS.Bloc.IService;
using XcelTech.HRMS.Bloc.Service;
using Microsoft.OpenApi.Models;
using System.Text;
using XcelTech.HRMS.Bloc;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using StackExchange.Redis;
using System.Configuration;


var builder = WebApplication.CreateBuilder(args);

Microsoft.Extensions.Configuration.ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomIdentity(builder.Configuration);
//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerDocumentation();

builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("localhost"));
builder.Services.AddHttpClient();

builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddFluentEmail(builder.Configuration);

builder.Services.AddAutoMapper(typeof(RegInfo_AppUser));
builder.Services.AddAutoMapper(typeof(UserProfile));
builder.Services.AddAutoMapper(typeof(ProfileInfoDto));
builder.Services.AddAutoMapper(typeof(PayRollGetProfile));
builder.Services.AddAutoMapper(typeof(PayRollPostProfile));

builder.Services.AddTransient<IEmailsender, EmailSender>();
builder.Services.AddTransient<IAutoGenerateId, AutoGenerateId>();


ServiceRegistrations.RegisterScopedServices(builder.Services);


builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("vite", PolicyBuilder =>
    {
        PolicyBuilder.WithOrigins("http://localhost:5173");
        PolicyBuilder.AllowAnyHeader();
        PolicyBuilder.AllowAnyMethod();
        PolicyBuilder.AllowCredentials();
    }
   );
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ManageDepartment", policy =>
        policy.RequireRole("manager"));

    options.AddPolicy("ViewDepartment", policy =>
        policy.RequireRole( "manager", "employee"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();

}



app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseCors("vite");

app.Run();

