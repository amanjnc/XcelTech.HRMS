using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcelTech.HRMS.Bloc.IService
{
    public interface IFilehandleService
    {

        Task<string> SaveFile(string base64String, string fileType);

        Task<string> FileToBase64Async(string filePath);

        string GetContentType(string fileName);

        void DeleteFiles(params string[] filePaths);
    }
}
