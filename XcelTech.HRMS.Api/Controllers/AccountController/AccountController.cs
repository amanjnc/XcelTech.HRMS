using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Bloc.IService;
using Microsoft.AspNetCore.Authorization;
using XcelTech.HRMS.Bloc.Service;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier;

namespace XcelTech.HRMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ICacheService _cacheService;
        private readonly IRegisterService _registerService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailsender _emailSender;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILoginService _loginService;



        public AccountController(ICacheService cacheService, UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager, IRegisterService registerService, ILoginService loginService, IEmailsender emailSender)
        {
            _cacheService = cacheService;
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

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewUserDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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


        //[HttpGet("GetAllRoles")]
        //public async Task<ActionResult<List<string>>> getAllRoles()
        //{
        //    return await _departmentService.getAllDepartment();
        //public async Task<ActionResult<UserBasket>> GetBasket(string id)
        //{
        //    // if the basket not found create new Basket and return it 
        //    var basket = await _basketRepository.GetBasketAsync(id);

        //    return basket ?? new UserBasket(id);
        //}

        [HttpGet("getREst")]
        public async Task<IActionResult> GetReset([FromQuery] string uniqueId)
        {
            try
            {
                var cacheData = await _cacheService.GetData(uniqueId);
                if (cacheData == null)
                {
                    return NotFound("The password reset link is invalid. NO SUCH uniqueID");
                }
                return Ok(cacheData);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the redis password reset data.");
            }
        }

        //[HttpGet("isValidResetLink")]
        //public async Task<ActionResult<bool>> IsValidResetLink([FromQuery] string id, [FromQuery] string uId)
        //{
        //    try
        //    {
        //        var cacheData = await _cacheService.GetData(id) ;
        //        if (cacheData != null && cacheData.AppUserId == uId  )
        //             return true;
        //        return false;

        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the password reset data.");
        //    }
        //}


        [HttpGet("isValidResetLink")]
        public async Task<ActionResult<bool>> IsValidResetLink([FromQuery] string uniqueId)
        {
            try
            {
                bool isValid = await _cacheService.GetData(uniqueId) != null;
                return isValid;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the password reset data.");
            }
        }
        [HttpPost("SetPassword")]
        public async Task<IActionResult> SetPassword([FromBody] PasswordDto passwordDto, [FromQuery] string uniqueId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cachedData = await _cacheService.GetData(uniqueId);
            if (cachedData == null)
            {
                return NotFound($"No cached data found for uniqueId: {uniqueId}");
            }

            string appUserId = cachedData.AppUserId;

            try
            {
                var result = await _registerService.setPasswordForExistingUser(passwordDto, appUserId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as per your application's error handling mechanism
                return StatusCode(500, "An error occurred while setting the password.");
            }
        }
        [HttpPost("ResetPasswordEmail")]
        public async Task<IActionResult> ResetPasswordEmail([FromBody] string email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var profilinfoDto = new ProfileInfoDto
                    {
                        EmployeeEmail = email,

                    };

                    var result = await _registerService.resetEmail(profilinfoDto);
                    return Ok(result);
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        }
    }

}



