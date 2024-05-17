using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcelTech.HRMS.Model.Dto
{
    public class EmployeeGetDto
    {

        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }

        public string? EmployeeImage { get; set; }

        public string? PhotoId { get; set; }

        public string? EmployeeEmail { get; set; }

        public string? DepartmentName { get; set; }

        public string? Role { get; set; }
    }
}