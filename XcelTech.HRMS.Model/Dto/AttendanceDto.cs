using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcelTech.HRMS.Model.Dto
{
    public class AttendanceDto
    {
        //public int AttendanceId { get; set; }
        //public DateOnly Date { get; set; }

        public string ClockinTime { get; set; }
        public string? ClockoutTime { get; set; }

        public TimeOnly? TotalTime { get; set; }

        public DateOnly date { set; get; }

        public string EmployeeName {  get; set; }
    }
}
