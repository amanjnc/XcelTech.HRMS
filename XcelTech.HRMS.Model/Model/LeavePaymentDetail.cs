using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcelTech.HRMS.Model.Model
{
    public class LeavePaymentDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeavePaymentDetailId { get; set; }

        public int LeaveTypeId { get; set; }
        [ForeignKey("LeaveTypeId")]
        //public LeaveTypes LeaveType { get; set; }
        public virtual LeaveTypes LeaveType { get; set; }

        public int DaysFrom { get; set; }
        public int DaysTo { get; set; }
        public double PaymentPercentage { get; set; }
    }
}
