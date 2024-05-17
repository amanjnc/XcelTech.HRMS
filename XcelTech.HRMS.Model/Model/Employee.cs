using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XcelTech.HRMS.Model.Model
{
    public class Employee

    {
        public int EmployeeId { get; set; }

        [Required]
        public string? EmployeeFirstName { get; set; }
        public string? EmployeeLastName { get; set; }

        public string? EmployeeImage { get; set; } //profilephoto
        public string? EducationCredentials { get; set; }
        public string? PhotoId {get; set;}


        //public int? EmployeeAge { get; set; } = 0;
        public DateOnly? EmployyDOB { get; set; } 
        public DateOnly? EmployeeHiredDate { get; set; } 

        public string? EmployeeAddress { get; set; }  = string.Empty;
        public string? EmployeePhone { get; set; }

        [EmailAddress]
        public string? EmployeeEmail { get; set; }

        public string? Gender { get; set; }

        public int? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
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

        public virtual ICollection<Attendance> Attendances { get; set; }



    }
}
