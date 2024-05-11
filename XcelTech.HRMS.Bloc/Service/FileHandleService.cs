using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
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
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileHandleService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> FilehandlePath(IFormFileCollection files, string email)
        {
            foreach (var source in files)
            {
                string fieldname = source.Name;
                string Filename = source.FileName;
                string FileExtension = Path.GetExtension(Filename);
                string Filepath = GetFilePath(email);

                if (!Directory.Exists(Filepath))
                {
                    Directory.CreateDirectory(Filepath);
                }

                // This is the file path, not just the image path
                string imagepath = Path.Combine(Filepath, fieldname + FileExtension);

                if (File.Exists(imagepath))
                {
                    File.Delete(imagepath);
                }

                using (FileStream stream = File.Create(imagepath))
                {
                    await source.CopyToAsync(stream);
                }

            
            }

            return null;
        }

        private string GetFilePath(string ProductCode)
        {
            return Path.Combine(_webHostEnvironment.WebRootPath, "\\Images\\", ProductCode);
        }
    }
}