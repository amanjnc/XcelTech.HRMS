using System.ComponentModel.DataAnnotations.Schema;

namespace XcelTech.HRMS.Model.Model
{
    public class Employee

    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeAge { get; set; }
        public DateOnly EmployyDOB { get; set; }
        public DateOnly EmployeeHiredDate { get; set; }

        public string EmployeeAddress { get; set; }
        public int EmployeePhone { get; set; }
        public string EmployeeEmail { get; set; }

        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentID")]
        public Department department { get; set; }


        public int ProjectId;
        [ForeignKey("ProjectId")]
        public Project project { get; set; }


        public int PayrollId { get; set; }
        [ForeignKey("PayrollId")]

        public Payroll payroll { get; set; }
    }
}
