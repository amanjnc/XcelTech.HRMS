using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Model;

namespace XcelTech.HRMS.Model.Dto
{
    public class GetLeaveDto
    {
        public int LeaveId { get; set; }


        public string LeaveType { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }


        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public String EmployeeEmail { get; set; }

        public string employeeName { get; set; }

        public string status { get; set; }
  
    }
}
