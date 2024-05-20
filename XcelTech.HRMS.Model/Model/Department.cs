using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;


namespace XcelTech.HRMS.Model.Model
{
    public class Department
    {
        
        public int DepartmentId { get; set; }

        [Required]
        public string? DepartmentName { get; set; }
        public string? DepartmentDescription { get; set; }

    }
}
