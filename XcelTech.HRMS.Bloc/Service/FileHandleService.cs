using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Bloc.IService;

namespace XcelTech.HRMS.Bloc.Service
{
    public class FileHandleService : IFilehandleService
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public FileHandleService(IWebHostEnvironment webHostEnvironment)
        {
            _hostingEnvironment = webHostEnvironment;
        }


        public async Task<string> SaveFile(string base64String, string fileType)
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


        public async Task<string> FileToBase64Async(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return null;
            }

            var absoluteFilePath = Path.Combine(_hostingEnvironment.WebRootPath, filePath);
            if (!System.IO.File.Exists(absoluteFilePath))
            {
                return null;
            }

            byte[] fileBytes = await System.IO.File.ReadAllBytesAsync(absoluteFilePath);
            var contentType = GetContentType(filePath); // Use the method to get content type

            return $"data:{contentType};base64,{Convert.ToBase64String(fileBytes)}";
        }

        public string GetContentType(string fileName)
        {
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(fileName, out var contentType))
            {
                contentType = "application/octet-stream"; // Default content type if not found
            }
            return contentType;
        }

        public void DeleteFiles(params string[] filePaths)
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