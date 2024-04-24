using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using XcelTech.HRMS.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Xml.Linq;
using XcelTech.HRMS.Model.Model;


namespace XcelTech.HRMS.Repo
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {

        }

        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Recruitment> Recruitments { get; set; }
        public DbSet<Training> Training { get; set; }


    

    }
}




