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

        //defined in employee repository
        //public async Task addEmployyetoTable(Employee employee)
        //{

        //    _applicationDbContext.Employees.Add(employee);
        //    await _applicationDbContext.SaveChangesAsync();

        //}

        //public async Task<IdentityResult> createUser(AppUser appUser, string password, Employee employee)
        //{

        //    //not sure though but it is an internal password hashing-with salt PBKDF2 (Password-Based Key Derivation Function 2)
        //    var createdUser = await _userManager.CreateAsync(appUser, password);
        //    return createdUser;
        //}


        public async Task<IdentityResult> createUser(AppUser appUser)
        {

            //not sure though but it is an internal password hashing-with salt PBKDF2 (Password-Based Key Derivation Function 2)
            var createdUser = await _userManager.CreateAsync(appUser);
            return createdUser;
        }

        public async Task<IdentityResult> createAdminWithPassword(AppUser appUser, string password)
        {
            var createdUser = await _userManager.CreateAsync(appUser,password);
            return createdUser;
        }





        public async Task<IdentityResult> createRole(AppUser appUser, string userRole)
        {
            var roleResult = await _userManager.AddToRoleAsync(appUser, userRole);
            return roleResult;

        }

        public async Task<bool> isUniqueEmail(string Email, CancellationToken token)
        {

            var existingUserWithSameEmail = await _userManager.FindByEmailAsync(Email);
            return existingUserWithSameEmail == null;

        }
        //var user = await _userManager.FindByEmailAsync(Email);
        //var roles = await _userManager.GetRolesAsync(user);
        //return roles.Name




        /////login part 
        ///





        public async Task<AppUser> checkOnlyEmail(DtoToLogin login)
        {
            return await _userManager.Users.FirstOrDefaultAsync(u => u.Email == login.EmployeeEmail);

        }

        public async Task<SignInResult> checkPasswordThenSignIn(AppUser appUser, DtoToLogin login, bool rememberMe = false)
        {

            //internal password hashing then matching happens here
            var result = await _signInManager.CheckPasswordSignInAsync(appUser, login.Password, rememberMe);
            return result;
        }

        public async Task finalSignIN(AppUser appUser, bool RememberMe)
        {
            await _signInManager.SignInAsync(appUser, RememberMe);

        }


        public async Task<string> getRoleOfUser(AppUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            if (roles.Count > 0)
            {

                return roles[0];
            }
            return null;
        }

        public async Task<IdentityResult> setPasswordForExistingUser(PasswordDto password, string appUserId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(appUserId);
                Console.WriteLine(4);

                if (user == null)
                {
                    Console.WriteLine(5);
                    return IdentityResult.Failed(new IdentityError
                    {
                        Code = "UserNotFound",
                        Description = $"User with ID '{appUserId}' not found."
                    });
                }

                Console.WriteLine(23);

                // Check if the user's password hash is null
                if (string.IsNullOrEmpty(user.PasswordHash))
                {
                    // Set the password directly
                    var setPasswordResult = await _userManager.AddPasswordAsync(user, password.Password);
                    if (!setPasswordResult.Succeeded)
                    {
                        Console.WriteLine(200);
                        return setPasswordResult;
                    }
                }
                else
                {
                    Console.WriteLine("froget abt it");
                    //i know it looks bad, when you can try to make it in 1 call since there might be failure after deletion
                    await _userManager.RemovePasswordAsync(user);
                    var result = await _userManager.AddPasswordAsync(user, password.Password);
                     if (!result.Succeeded)
                     {
                         Console.WriteLine(9);

                         return result;
                     }

                }

                await _userManager.UpdateAsync(user);
                Console.WriteLine(10);
                return IdentityResult.Success;
            }
            catch (Exception ex)
            {
                Console.WriteLine(111);
                return IdentityResult.Failed(new IdentityError
                {
                    Code = "InternalServerError",
                    Description = "An error occurred while setting the password."
                });
            }
        }


    }
}