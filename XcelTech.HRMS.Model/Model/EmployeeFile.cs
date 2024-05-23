using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcelTech.HRMS.Model.Model
{
    public class EmployeeFile
    {
        [Key, ForeignKey("employee")]
        public int EmployeeId { get; set; }

        //[ForeignKey("EmployeeId")]

        public Employee employee { get; set; }
        public string Resume { get; set; } 
        public string? Certeficate { get; set; }

        public string EducationalCredential { get; set; }
    }
}
