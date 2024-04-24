namespace XcelTech.HRMS.Model.Model
{
    public class Payroll
    {

        public int PayrollId { get; set; }
        public string payrollpay { get; set; }
        public DateOnly PayrollStartDate { get; set; }
        public DateOnly PayrollEndDate { get; set; }
        public float DeductionsAndBonus { get; set; }
        public float NetPay { get; set; }


    }
}
