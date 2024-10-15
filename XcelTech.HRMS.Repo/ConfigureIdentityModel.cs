using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcelTech.HRMS.Repo
{
    public class ConfigureIdentityModel
    {
        public static void ConfigureIdentity(ModelBuilder builder)
        {
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "employee",
                    NormalizedName = "EMPLOYEE"
                },
                new IdentityRole
                {
                    Name = "hr",
                    NormalizedName = "HR"
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
