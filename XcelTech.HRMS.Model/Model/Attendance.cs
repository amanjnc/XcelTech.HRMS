using System.ComponentModel.DataAnnotations.Schema;
using XcelTech.HRMS.Model.Model;

namespace XcelTech.HRMS.Model
{
    public class Attendance
    {
        //can use Guid(Globally unique identifire) but for similicity
        public int AttendanceId { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly ClockInTime { get; set; }
        public TimeOnly ClockOutTime { get; set; }
        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeID")]

        public Employee Employee { get; set; }
        //Notsure but better to make emp_id a fk rather than  making attendace_id a fk



    }
}
