using Microsoft.AspNetCore.Mvc;
using XcelTech.HRMS.Bloc.IService;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Repo;
using Microsoft.AspNetCore.Authorization;
using System;
using XcelTech.HRMS.Model.Model;
using System.Security.Claims;
using System.IO;

namespace XcelTech.HRMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeControllers : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private static IWebHostEnvironment _environment;
       

        public EmployeeControllers(IEmployeeService employeeService ,IWebHostEnvironment environment)
        {
            _employeeService = employeeService;
            _environment = environment;
        }

        [Authorize]
        [HttpPatch("AddProfile")]
        public async Task<ActionResult<string>> AddProfile([FromForm] ProfileInfoDto profileInfoDto)
        {
            try
            {
                string imagepath = null;
                if (ModelState.IsValid)
                {
                    var email = HttpContext.User.FindFirstValue(ClaimTypes.Email);
                    Console.WriteLine($"current email: {email}");

                    var _uploadedfiles = Request.Form.Files;
                    foreach (IFormFile source in _uploadedfiles)
                    {
                        string fieldname=source.Name;
                        string Filename = source.FileName;
                        string FileExtension = Path.GetExtension(Filename);
                        string Filepath = GetFilePath(email);

                        if (!System.IO.Directory.Exists(Filepath))
                        {
                            System.IO.Directory.CreateDirectory(Filepath);
                        }

                        //this is the file path not just the image path i didnt wanna change it everywhere
                        imagepath = Path.Combine(Filepath, fieldname + FileExtension);


                        if (System.IO.File.Exists(imagepath))
                        {
                            System.IO.File.Delete(imagepath);
                        }
                        using (FileStream stream = System.IO.File.Create(imagepath))
                        {
                            await source.CopyToAsync(stream);
                           
                            
                        }
                        //return imagepath;

                    }

                    var result = await _employeeService.updateEmployee(profileInfoDto, email, imagepath);



                    return Ok(result);

                }


                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        }

        /*[Authorize]
        [HttpGet("GetProfile")]
        public async Task<ActionResult<Employee>> GetProfile()
        {
            try
            {
                var email = HttpContext.User.FindFirstValue(ClaimTypes.Email);
                Console.WriteLine($"current email: {email}");

                var profileInfo = await _employeeService.GetEmployeeProfile(email);

                if (profileInfo != null)
                {
                    string base64Image = Convert.ToBase64String(profileInfo.EmployeeImage);
                    profileInfo.EmployeeAddress = $"data:image/png;base64,{base64Image}";
                    return Ok(profileInfo);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }*/

        private string GetFilePath(string ProductCode)
        {
            return _environment.WebRootPath + "\\Images\\" + ProductCode;
        }


    }



}

/*if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\+Images+\\"))
               {
                   Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\+Images+\\");
               }
               using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.WebRootPath + "\\+Images+\\" + profileInfoDto.EmployeeImage.FileName))
               {
                   profileInfoDto.EmployeeImage.CopyTo(fileStream);
                   fileStream.Flush();
                   //return "\\+Images+\\" + profileInfoDto.EmployeeImage.FileName;
               }*/