using System.ComponentModel.DataAnnotations.Schema;

namespace XcelTech.HRMS.Model.Model
{
    public class Recruitment
    {
        public int RecruitmentId { get; set; }
        public string Position { get; set; }
       
        public DateOnly StartDate { get; set; }
        public int DepartementID { get; set; }
        [ForeignKey("DepartmentId")]
        public Department department { get; set; }



        public int HiringManager { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee employee { get; set; }

    }

}
