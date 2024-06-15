using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace XcelTech.HRMS.Model.Model
{
    public class LeaveTypes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int LeaveTypeId { get; set; }
        public string? LeaveTypeName { get; set; }

        public bool IsPaid { get; set; }

        //public int FullyPaidDays { get; set; }

        //public int HalfPaidDays { get; set; }

        public bool DeductDays { get; set; }

        public int TotalAllowedDays {  get; set; }

        public virtual ICollection<LeavePaymentDetail>? LeavePaymentDetails { get; set; }


    }
}
