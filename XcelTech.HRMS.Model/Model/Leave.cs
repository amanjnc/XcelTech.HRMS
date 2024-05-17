using System.ComponentModel.DataAnnotations.Schema;

namespace XcelTech.HRMS.Model.Model
{

    public enum Status
    {
        Pending,
        Approved,
        Disapproved
    }
    public class Leave
    {
        public int LeaveId { get; set; }


        public string LeaveType { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }


        public int EmployeeId { get; set; }
       [ForeignKey("EmployeeId")]
       public Employee employee { get; set; }



        //public int? LeaveTypeId { get; set; }
        //[ForeignKey("LeaveTypeId")]
        //public LeaveTypes? LeaveTypes { get; set; }



        public string status { get; set; } = "Pending";

        //public int? DepartmentId { get; set; }
        //[ForeignKey("DepartmentId")]
        //public Department? department { get; set; }
    }
}
