using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo;

namespace XcelTech.HRMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeFileController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public EmployeeFileController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _applicationDbContext = context;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployeeFile([FromBody] EmployeeFileDto employeeFileDto, [FromQuery] int userId)
        {
            try
            {
                var employeeFile = new EmployeeFile
                {
                    EmployeeId = userId, // Use the userId from the query parameter
                    Resume = await SaveFile(employeeFileDto.Resume, "Resume"),
                    Certeficate = await SaveFile(employeeFileDto.Certeficate, "Certificate"),
                    EducationalCredential = await SaveFile(employeeFileDto.EducationalCredential, "EducationalCredential")
                };

                _applicationDbContext.EmployeeFiles.Add(employeeFile);
                await _applicationDbContext.SaveChangesAsync();

                return Ok(new { Message = "Files uploaded successfully", EmployeeFile = employeeFile });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeeFiles([FromQuery] int userId)
        {
            var employeeFiles = await _applicationDbContext.EmployeeFiles
                .Where(ef => ef.EmployeeId == userId)
                .ToListAsync();

            if (employeeFiles == null || !employeeFiles.Any())
            {
                return NotFound();
            }

            return Ok(employeeFiles);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployeeFiles([FromQuery] int userId)
        {
            var employeeFiles = await _applicationDbContext.EmployeeFiles
                .Where(ef => ef.EmployeeId == userId)
                .ToListAsync();

            if (employeeFiles == null || !employeeFiles.Any())
            {
                return NotFound();
            }

            try
            {
                // Delete associated files
                foreach (var employeeFile in employeeFiles)
                {
                    DeleteFiles(employeeFile.Resume, employeeFile.Certeficate, employeeFile.EducationalCredential);
                }

                _applicationDbContext.EmployeeFiles.RemoveRange(employeeFiles);
                await _applicationDbContext.SaveChangesAsync();

                return Ok(new { Message = "Employee files deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        private async Task<string> SaveFile(string base64String, string fileType)
        {
            if (string.IsNullOrEmpty(base64String))
            {
                return null;
            }

            var parts = base64String.Split(new[] { "base64," }, StringSplitOptions.None);
            var contentType = parts[0].Split(':')[1].Split(';')[0];
            var fileExtension = contentType.Split('/')[1];
            var fileBytes = Convert.FromBase64String(parts[1]);

            var fileName = $"{Guid.NewGuid()}.{fileExtension}";
            var relativeFilePath = Path.Combine("uploads", fileName);
            var absoluteFilePath = Path.Combine(_hostingEnvironment.WebRootPath, relativeFilePath);

            await System.IO.File.WriteAllBytesAsync(absoluteFilePath, fileBytes);

            return relativeFilePath;
        }

        private void DeleteFiles(params string[] filePaths)
        {
            foreach (var filePath in filePaths.Where(fp => !string.IsNullOrEmpty(fp)))
            {
                var absoluteFilePath = Path.Combine(_hostingEnvironment.WebRootPath, filePath);
                if (System.IO.File.Exists(absoluteFilePath))
                {
                    System.IO.File.Delete(absoluteFilePath);
                }
            }
        }
    }
}
