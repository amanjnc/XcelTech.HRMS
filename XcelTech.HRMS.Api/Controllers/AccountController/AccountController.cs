using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XcelTech.HRMS.Bloc;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Bloc.IService;

namespace XcelTech.HRMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IRegisterService _registerService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokeNService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        

        public AccountController(UserManager<AppUser> userManager, ITokeNService tokenService, SignInManager<AppUser> signInManager, IRegisterService registerService)
        {
            _registerService = registerService;
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] DtoRegister dtoRegister)
        {


            try { 

                if (ModelState.IsValid)
                {
                    var result =  await _registerService.createUser(dtoRegister);
                    return Ok(result);
                }
                    return BadRequest(ModelState);             
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] DtoToLogin login, bool rememberMe = false)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == login.EmployeeEmail.ToLower());
            if (user == null)
            {
                return Unauthorized("Invalid Email");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, rememberMe);

            if (!result.Succeeded)
            {
                return Unauthorized("Password incorrect");
            }

            await _signInManager.SignInAsync(user, rememberMe);


            var authCookie = Request.Cookies[".AspNetCore.Identity.Application"];

            Console.WriteLine($"Remember Me Cookie: {authCookie}");

            return Ok(new NewUserDto
            {
                EmployeeName = user.UserName,
                EmployeeEmail = user.Email,
                Token = _tokenService.CreateToken(user)
            });
}
    }
}





