using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;


namespace XcelTech.HRMS.Model.Dto
{
    public class ProfileInfoDto
    {
        public string? EmployeeName { get; set; }

        

        public IFormFile? EmployeeImage { get; set; }

        public int? EmployeeAge { get; set; }
        //public DateOnly? EmployeeDOB { get; set; }
        public string? EmployeeAddress { get; set; } = string.Empty;
        public int? EmployeePhone { get; set; }

        //[EmailAddress]
        //public string? EmployeeEmail { get; set; }

        public string? DepartmentName { get; set; }

        public IFormFile? PhotoId { get; set; }

        public IFormFile? EducationCredentials { get; set; }

        public string? Gender { get; set; }
    }
}
