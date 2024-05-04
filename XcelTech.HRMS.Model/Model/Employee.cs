using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XcelTech.HRMS.Model.Model
{
    public class Employee

    {
        public int EmployeeId { get; set; }




        [Required]
        public string EmployeeName { get; set; }

        public byte[]? EmployeeImage { get; set; }

        public int? EmployeeAge { get; set; } = 0;
        public DateOnly? EmployyDOB { get; set; } 
        public DateOnly? EmployeeHiredDate { get; set; } 

        public string EmployeeAddress { get; set; }  = string.Empty;
        public int? EmployeePhone { get; set; }

        [EmailAddress]
        public string? EmployeeEmail { get; set; } 

        public int? DepartmentId { get; set; }

        
        [ForeignKey("DepartmentID")]
        public Department? department { get; set; } 


        public int? ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public Project project { get; set; } 


        public int? PayrollId { get; set; }  
        [ForeignKey("PayrollId")]

        public Payroll payroll { get; set; } 


        // Add the foreign key property
        public string? AppUserId { get; set; } 

        // Define the relationship with AppUser
        [ForeignKey("AppUserId")]
        public AppUser AppUser { get; set; }



    }
}
