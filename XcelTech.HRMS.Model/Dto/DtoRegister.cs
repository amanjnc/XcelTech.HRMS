using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcelTech.HRMS.Model.Dto
{
    internal class DtoRegister

    {

        [Required]
        public string EmployeeName { get; set; } = String.Empty;


        [Required]
        [EmailAddress]
        public string EmployeeEmail { get; set; } = String.Empty;


        [Required]
        public string Password { get; set; } = String.Empty;    

    }
}
