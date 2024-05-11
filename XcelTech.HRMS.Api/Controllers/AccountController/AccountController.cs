using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Bloc.IService;
using Microsoft.AspNetCore.Authorization;
using XcelTech.HRMS.Bloc.Service;

namespace XcelTech.HRMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IRegisterService _registerService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailsender _emailSender;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILoginService _loginService;



        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager, IRegisterService registerService, ILoginService loginService, IEmailsender emailSender )
        {
            _emailSender = emailSender;
            _loginService = loginService;
            _registerService = registerService;
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }

        [HttpPost("RegisterAdmin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] DtoRegister dtoRegister)
        {


            try
            {

                if (ModelState.IsValid)
                {
                    var result = await _registerService.CreateAdmin(dtoRegister);
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

            var finalResult = await _loginService.checkPasswordThenSignIn(login, rememberMe);

            return Ok(finalResult);
        }


        //[Authorize]
        //[HttpGet("logout")]
        //public async Task logout() {




        //}

        //[HttpGet(userRoles)]
        //public async Task<IActionResult> getAllRoles()
        //{


        //}

        [HttpPost("emailRegistration")]
        public async Task<IActionResult> EmialRegisterationController([FromBody] EmailRegistrationModel model )
        {

           await _emailSender.SendEmailAsync(model.Email, model.Subject, model.Message);
            return Ok();
        }
        //[HttpGet("GetAllRoles")]
        //public async Task<ActionResult<List<string>>> getAllRoles()
        //{
        //    return await _departmentService.getAllDepartment();



        }
}




