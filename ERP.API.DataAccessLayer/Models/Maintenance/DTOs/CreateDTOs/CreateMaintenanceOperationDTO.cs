namespace ERP.API.DataAccessLayer.Models.Maintenance.DTOs.CreateDTOs
{
    public class CreateMaintenanceOperationDTO
    {
        [Required(ErrorMessage = "CustomerID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "CustomerID must be a positive number.")]
        public int? CustomerID { get; set; }

        [Required(ErrorMessage = "EmployeeID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "EmployeeID must be a positive number.")]
        public int? EmployeeID { get; set; }

        [Required(ErrorMessage = "ReceivedDate is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format for ReceivedDate.")]
        public DateTime? ReceivedDate { get; set; }

        [Required(ErrorMessage = "ExpectedDeliveryDate is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format for ExpectedDeliveryDate.")]
        public DateTime? ExpectedDeliveryDate { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Invalid date format for ActualDeliveryDate.")]
        public DateTime? ActualDeliveryDate { get; set; }

        [Required(ErrorMessage = "ItemDescription is required.")]
        [StringLength(500, ErrorMessage = "ItemDescription cannot exceed 500 characters.")]
        public string? ItemDescription { get; set; }

        [Required(ErrorMessage = "MaintenanceDetails are required.")]
        [StringLength(1000, ErrorMessage = "MaintenanceDetails cannot exceed 1000 characters.")]
        public string? MaintenanceDetails { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [StringLength(50, ErrorMessage = "Status cannot exceed 50 characters.")]
        public string? Status { get; set; }
    }
}
