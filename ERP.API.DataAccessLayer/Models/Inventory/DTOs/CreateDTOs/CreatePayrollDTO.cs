namespace ERP.API.DataAccessLayer.Models.Inventory.DTOs.CreateDTOs
{
    public class CreatePayrollDTO
    {
        [Required(ErrorMessage = "EmployeeID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "EmployeeID must be a positive number.")]
        public int? EmployeeID { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Invalid date format for PayPeriodStart.")]
        public DateTime? PayPeriodStart { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Invalid date format for PayPeriodEnd.")]
        public DateTime? PayPeriodEnd { get; set; }
    }
}
