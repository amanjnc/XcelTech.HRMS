using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcelTech.HRMS.Model.Dto
{
    public class LeavePaymentDetailDto
    {
        public int DaysFrom { get; set; }
        public int DaysTo { get; set; }
        public double PaymentPercentage { get; set; }
    }
}
