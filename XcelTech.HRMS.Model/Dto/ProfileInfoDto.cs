using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcelTech.HRMS.Model.Dto
{
    public class ProfileInfoDto
    {
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }

        public string adminAssignedRole{ get; set; }

        //public IFormFile? EmployeeImage { get; set; }
        //public IFormFile? PhotoId { get; set; }

        //public IFormFile? EducationCredentials { get; set; }

        //public int? EmployeeAge { get; set; }
        public DateOnly? EmployyDOB { get; set; }
        public string? EmployeeAddress { get; set; } = string.Empty;
        
      
        public string? EmployeePhone { get; set; }

        public long BankAccountNumber { get; set; }


        //public IFormFile employeeId{ get; set; }
        [EmailAddress]
        public string? EmployeeEmail { get; set; }
        public string? Gender { get; set; }
        public string? DepartmentName { get; set; }
    }
}
