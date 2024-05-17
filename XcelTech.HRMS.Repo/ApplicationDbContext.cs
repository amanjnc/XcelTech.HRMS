using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using XcelTech.HRMS.Model;
using XcelTech.HRMS.Model.Model;
using Microsoft.AspNetCore.Identity;

namespace XcelTech.HRMS.Repo
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.EnableSensitiveDataLogging();
                //optionsBuilder.UseNpgsql("Server=localhost;Database=Hrms;User Id=postgres;Password=1234;");
                optionsBuilder.UseNpgsql("Host=xcelTech.hrms.repo;Port=5432;Database=xceltechhrmsNewww;Username=postgres;Password=postgres;Include Error Detail=true;");
            }
        }

        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<LeaveTypes> LeaveTypes  { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Recruitment> Recruitments { get; set; }
        public DbSet<Training> Training { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Attendance>()
     .HasOne(a => a.employee)
     .WithMany(e => e.Attendances)
     .HasForeignKey(a => a.EmployeeId)
     .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Employee>()
                .HasOne(e => e.AppUser)
                .WithOne(u => u.Employee)
                .HasForeignKey<Employee>(e => e.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}