using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo.IRepo;

namespace XcelTech.HRMS.Repo.Repo
{
    public class AccountRegister : IAccountRegister
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _applicationDbContext;

        public AccountRegister(UserManager<AppUser> userManager, ApplicationDbContext applicationDbContext)

        {
            _userManager = userManager;
            _applicationDbContext = applicationDbContext;
        }
        public async Task addEmployyetoTable(Employee employee)
        {

            _applicationDbContext.Employees.Add(employee);
            await _applicationDbContext.SaveChangesAsync();

        }

        public async Task<IdentityResult> createUser(AppUser appUser, string password, Employee employee)
        {


            var createdUser = await _userManager.CreateAsync(appUser, password);
            return createdUser;
        }


        public async Task<IdentityResult> createRole(AppUser appUser, string  userRole)
        {
            var roleResult = await _userManager.AddToRoleAsync(appUser, userRole );
            return roleResult;

        }

        public async Task<bool> isUniqueEmail(string Email, CancellationToken token)
        {

            var existingUserWithSameEmail = await _userManager.FindByEmailAsync(Email);
            return existingUserWithSameEmail == null;

        }

    }
}