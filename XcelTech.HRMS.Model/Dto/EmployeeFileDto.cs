using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Model;

namespace XcelTech.HRMS.Model.Dto
{
    public class EmployeeFileDto
    {
            
        
        //public int EmployeeId { get; set; }

        public string Resume { get; set; }
        public string? Certeficate { get; set; }

        public string EducationalCredential { get; set; }
    }
}

