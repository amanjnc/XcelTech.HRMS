using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XcelTech.HRMS.Model.Model;

namespace XcelTech.HRMS.Model.Dto
{

    public class LeaveTypeDto
    {
        public string? LeaveTypeName { get; set; }
        public bool IsPaid { get; set; }
        public bool DeductDays { get; set; }
        public int TotalAllowedDays { get; set; }
        public List<LeavePaymentDetailDto>? LeavePaymentDetails { get; set; }
    }
}

