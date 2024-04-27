using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo.IRepo;

namespace XcelTech.HRMS.Repo.Repo
{
    public class AccountRegister : IAccountRegister
    {
        private readonly UserManager<AppUser> _userManager;
        //private readonly ITokeNService _tokenService;
        private readonly ApplicationDbContext _applicationDbContext;



        public AccountRegister(UserManager<AppUser> userManager, ApplicationDbContext applicationDbContext)

        {
            _userManager = userManager;
            //_tokenService = tokenService;
            _applicationDbContext = applicationDbContext;
        }




        public async Task addEmployyetoTable(Employee employee)
        {

            _applicationDbContext.Employees.Add(employee);
            await _applicationDbContext.SaveChangesAsync();

        }




        public async Task<IActionResult> createEmployee (AppUser appUser, string password,Employee employee)
        {




            var createdUser = await _userManager.CreateAsync(appUser, password);
            
                
            

            if (createdUser.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(appUser, "buyer");

                if (roleResult.Succeeded)
                {

                    var newUserDto = new NewUserDto
                    {
                        EmployeeName = appUser.UserName,
                        EmployeeEmail = appUser.Email,
                        //Token = _tokenService.CreateToken(appUser)
                    };





                    return new OkObjectResult(newUserDto);
                }
                else
                {
                    var errorMessage = "Failed to add user to the buyer role. Reason: " + GetIdentityErrorMessage(roleResult.Errors);
                    throw new Exception(errorMessage);
                }
            }
            else
            {
                var errorMessage = "Failed to create user. Reason: " + GetIdentityErrorMessage(createdUser.Errors);
                throw new Exception(errorMessage);
            }
        }



        public async Task<bool> isUniqueEmail(string Email, CancellationToken token)
        {

            var existingUserWithSameEmail = await _userManager.FindByEmailAsync(Email);
            return existingUserWithSameEmail == null;

        }



        private string GetIdentityErrorMessage(IEnumerable<IdentityError> errors)
        {
            return string.Join(", ", errors.Select(e => e.Description));
        }


    }
}