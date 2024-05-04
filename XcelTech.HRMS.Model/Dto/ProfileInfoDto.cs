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
        //public string EmployeeName { get; set; }

        //public byte[]? EmployeeImage { get; set; }

        public int? EmployeeAge { get; set; }
        //public DateOnly? EmployyDOB { get; set; }
        public string? EmployeeAddress { get; set; } = string.Empty;
        //public int? EmployeePhone { get; set; }

        //[EmailAddress]
        //public string? EmployeeEmail { get; set; }

        public string? DepartmentName { get; set; }
    }
}
