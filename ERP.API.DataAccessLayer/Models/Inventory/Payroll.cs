namespace ERP.API.DataAccessLayer.Models.Inventory
{
    public class Payroll : Analysis
    {
        public int? PayrollID { get; set; }
        public int? EmployeeID { get; set; }
        public DateTime? PayPeriodStart { get; set; }
        public DateTime? PayPeriodEnd { get; set; }
        public decimal? TotalHoursWorked { get; set; }
        public decimal? RegularHours { get; set; }
        public decimal? OvertimeHours { get; set; }
        public decimal? DoubleOvertimeHours { get; set; }
        public decimal? RegularPay { get; set; }
        public decimal? OvertimePay { get; set; }
        public decimal? DoubleOvertimePay { get; set; }
        public decimal? TotalPay { get; set; }
        public Payroll() : base()
        {
            TotalPay = null;
            PayPeriodStart = null;
            PayPeriodEnd = null;
            TotalHoursWorked = null;
            RegularHours = null;
            OvertimeHours = null;
            DoubleOvertimeHours = null;
            RegularPay = null;
            OvertimePay = null;
            DoubleOvertimePay = null;
            TotalPay = null;
        }
    }
}
