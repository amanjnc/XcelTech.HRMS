using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace XcelTech.HRMS.Model.Dto
{
    public class DtoRegister

    {

 
        public string EmployeeName { get; set; } = String.Empty; 


        public string EmployeeEmail { get; set; } = String.Empty;

        public string Password { get; set; } = String.Empty;    

    }
}
