using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Repo;

namespace XcelTech.HRMS.Repo

{
    public class ApplicationDbContextFactory
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseNpgsql("Host =localhost;Port=5432;Database=Hrms;User Id = postgres; Password =Portal_0");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}