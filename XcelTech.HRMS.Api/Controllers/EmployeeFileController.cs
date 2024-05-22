using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace XcelTech.HRMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeFileController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public EmployeeFileController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFiles([FromQuery] int userId, [FromBody] List<string> base64Files)
        {
            try
            {
                foreach (var base64File in base64Files)
                {
                    // Decode the Base64 string into bytes
                    byte[] fileBytes = Convert.FromBase64String(base64File);

                    // Generate a unique filename
                    string fileName = $"{Guid.NewGuid()}.dat";

                    // Specify the file path where the file will be saved
                    string relativeFilePath = Path.Combine("uploads", fileName);
                    string absoluteFilePath = Path.Combine(_hostingEnvironment.WebRootPath, relativeFilePath);

                    // Write the file to disk
                    await System.IO.File.WriteAllBytesAsync(absoluteFilePath, fileBytes);

                    // Save the relative file path in the database or perform any additional processing
                    string savedFilePath = $"/{relativeFilePath}";
                    Console.WriteLine($"File saved: {savedFilePath}");
                }

                return Ok($"Received userId: {userId}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
