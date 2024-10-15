using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Model;

namespace XcelTech.HRMS.Model.Dto
{
    public class LeaveDto
    {
        public string LeaveType { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

       // public int DepartmentId { get; set; }
       // [ForeignKey("DepartmentId")]
       // public Department department { get; set; }
    }
}
