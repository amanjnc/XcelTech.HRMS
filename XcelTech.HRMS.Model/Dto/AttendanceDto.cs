using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcelTech.HRMS.Model.Dto
{
    public class AttendanceDto
    {
        public DateOnly Date { get; set; }
        public TimeOnly ClockInTime { get; set; }
        public TimeOnly ClockOutTime { get; set; }
    }
}
