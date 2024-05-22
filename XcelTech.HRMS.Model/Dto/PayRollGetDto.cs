using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XcelTech.HRMS.Model.Dto
{
        public class PayRollGetDto
        {

            public string EmployeeName {  get; set; }

            public int EmployeeId { get; set; }

            public string SalaryType { get; set; }

            public Double Amount { get; set; }

            public string PaymentDuration { get; set; }

            public string PaymentMethod { get; set; }

            public DateOnly PaymentDate { get; set; }
            public string PaymentStatus { get; set; } = string.Empty;

            public float Bonus { get; set; }

            public DateOnly PayrollStartDate { get; set; }
            public DateOnly PayrollEndDate { get; set; }

            public float NetPay { get; set; }


        }
    }


