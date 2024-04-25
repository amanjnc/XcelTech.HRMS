using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcelTech.HRMS.Model.Dto
{
    public class DtoRegisterER
    {

        [Required]
        [EmailAddress]
        public string EmployeeEmail { get; set; } = String.Empty;


        [Required]
        public string Password { get; set; } = String.Empty;
        //public string Token { get; set; } = string.Empty ;
    }

}
