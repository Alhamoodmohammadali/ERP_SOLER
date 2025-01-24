namespace ERP.API.DataAccessLayer.Models.HRM
{
    public class Employee : Person
    {
        public int? EmployeeID { get; set; }
        public DateTime? HireDate { get; set; }
        public string? JobTitle { get; set; }
        public decimal? Salary { get; set; }
        public string? Department { get; set; }
        public Employee() : base()
        {
            EmployeeID = null;
            HireDate = null;
            JobTitle = null;
            Salary = null;
            Department = null;
        }
    }
}
