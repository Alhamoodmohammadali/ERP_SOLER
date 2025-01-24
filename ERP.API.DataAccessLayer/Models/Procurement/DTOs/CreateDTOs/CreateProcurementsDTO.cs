namespace ERP.API.DataAccessLayer.Models.Procurement.DTOs.CreateDTOs
{
    public class CreateProcurementsDTO
    {

        [Required(ErrorMessage = "SupplierID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "SupplierID must be a positive number.")]
        public int? SupplierID { get; set; }

        [Required(ErrorMessage = "PurchaseDate is required.")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid date format for PurchaseDate.")]
        public DateTime? PurchaseDate { get; set; }

        [Required(ErrorMessage = "TotalAmount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "TotalAmount must be a positive value.")]
        public decimal? TotalAmount { get; set; }

        [Required(ErrorMessage = "PaymentMethod is required.")]
        [StringLength(50, ErrorMessage = "PaymentMethod cannot exceed 50 characters.")]
        public string? PaymentMethod { get; set; }

        [Required(ErrorMessage = "ProcurementStatus is required.")]
        [StringLength(50, ErrorMessage = "ProcurementStatus cannot exceed 50 characters.")]
        public string? ProcurementStatus { get; set; }
    }
}
