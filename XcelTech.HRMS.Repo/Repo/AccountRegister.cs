using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using XcelTech.HRMS.Repo.IRepo;

namespace XcelTech.HRMS.Repo.Repo
{
    public class AccountRegister : IAccountRegister
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly SignInManager<AppUser> _signInManager;


        public AccountRegister(UserManager<AppUser> userManager, ApplicationDbContext applicationDbContext, SignInManager<AppUser> signInManager)

        {
            _userManager = userManager;
            _applicationDbContext = applicationDbContext;
            _signInManager = signInManager;
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




        /////login part 
        ///





        public async Task<AppUser> checkOnlyEmail(DtoToLogin login)
        {
            return await  _userManager.Users.FirstOrDefaultAsync(u => u.Email == login.EmployeeEmail.ToLower());
            
        }

        public async Task<SignInResult> checkPasswordThenSignIn(AppUser appUser, DtoToLogin login, bool rememberMe = false)
        {
            var result = await _signInManager.CheckPasswordSignInAsync(appUser, login.Password, rememberMe);
            return result; 
        }

        public async Task finalSignIN(AppUser appUser, bool RememberMe)
        {
            await _signInManager.SignInAsync(appUser, RememberMe);

        }



    





    }
}