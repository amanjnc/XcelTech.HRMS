using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;



namespace XcelTech.HRMS.Model.Model
{
    public class Payroll
    {

        public int PayrollId { get; set; }

        //public string EmployeeName {  get; set; }

        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]

       

        public string SalaryType {  get; set; }

        public Double Amount { get; set; }

        public string PaymentDuration {  get; set; }

        public string PaymentMethod { get; set; }

        public DateOnly PaymentDate { get; set; }
        public string PaymentStatus { get; set; } = string.Empty;

        public float Bonus { get; set; }

        public DateOnly PayrollStartDate { get; set; }
        public DateOnly PayrollEndDate { get; set; }

        public float NetPay { get; set; }


    }
} 
