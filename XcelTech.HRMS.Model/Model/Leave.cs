using System.ComponentModel.DataAnnotations.Schema;

namespace XcelTech.HRMS.Model.Model
{
    public class Leave
    {
        public int LeaveId { get; set; }


        public string LeaveReasonType { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }


        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee employee { get; set; }
    }
}
