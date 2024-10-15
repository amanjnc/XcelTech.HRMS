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
        Task<string> FilehandlePath(IFormFileCollection files, string email);
    }
}
