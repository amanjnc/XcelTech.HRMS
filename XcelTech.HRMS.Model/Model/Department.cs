using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;


namespace XcelTech.HRMS.Model.Model
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public string? DepartmentDescription { get; set; }

    }
}
