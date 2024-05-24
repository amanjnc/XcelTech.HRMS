using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Bloc.IService;
using XcelTech.HRMS.Model.Dto;
using XcelTech.HRMS.Model.Model;
using XcelTech.HRMS.Repo;
using Microsoft.AspNetCore.StaticFiles;
using XcelTech.HRMS.Repo.IRepo;
using Microsoft.AspNetCore.Http;

namespace XcelTech.HRMS.Bloc.Service
{
    public class EmployeeFileService : IEmployeeFileService
    {

        private readonly IWebHostEnvironment _hostingEnvironment;
        private IFilehandleService _filehandleService;
        private readonly IEmployeeFileRepository _employeeFileRepository;
        public EmployeeFileService(IWebHostEnvironment hostingEnvironment, IEmployeeFileRepository employeeFileRepository, IFilehandleService filehandleService)
        {
            _hostingEnvironment = hostingEnvironment;
            _employeeFileRepository = employeeFileRepository;
            _filehandleService = filehandleService;

            
        }

        public async Task<IActionResult> CreateEmployeeFile(EmployeeFileDto employeeFileDto, int UserId)
        {
            try
            {
                var employeeFile = new EmployeeFile
                {
                    EmployeeId = UserId, // Use the userId from the query parameter
                    Resume = await _filehandleService.SaveFile(employeeFileDto.Resume, "Resume"),
                    Certeficate = await _filehandleService.SaveFile(employeeFileDto.Certeficate, "Certificate"),
                    EducationalCredential = await _filehandleService.SaveFile(employeeFileDto.EducationalCredential, "EducationalCredential"),
                    EmployeeImage = await _filehandleService.SaveFile(employeeFileDto.EmployeeImage, "EmployeeImage")
                };

                await _employeeFileRepository.CreateEmployeeFile(employeeFile);

                return new OkResult();
            }
            catch (Exception ex)
            {
                return new ObjectResult(new { error = $"An error occurred: {ex.Message}" })
                {
                    StatusCode = 500
                };
            }
        }

        public async Task<IActionResult> DeleteEmployeeFile(int userId)
        {
            try
            {
                var employeeFile = await _employeeFileRepository.DeleteEmployeeFile(userId);


                _filehandleService.DeleteFiles(employeeFile.Resume, employeeFile.Certeficate, employeeFile.EducationalCredential,employeeFile.EmployeeImage);

                // Remove the employee file from the database

                return new OkResult();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it in an appropriate way
                return new ObjectResult(new { error = $"An error occurred: {ex.Message}" })
                {
                    StatusCode = 500
                };
            }
        }
        public async Task<EmployeeFileDto> GetEmployeeFileById(int userId)
        {
            var employeeFile = await _employeeFileRepository.GetEmployeeFile(userId);

            var fileDto = new EmployeeFileDto
            {
                Resume = await _filehandleService.FileToBase64Async(employeeFile.Resume),
                Certeficate = await _filehandleService.FileToBase64Async(employeeFile.Certeficate),
                EducationalCredential = await _filehandleService.FileToBase64Async(employeeFile.EducationalCredential),
                EmployeeImage = await _filehandleService.FileToBase64Async(employeeFile.EmployeeImage)
            };

            return fileDto;
        }




    }

}
