namespace ERP.API.DataAccessLayer.Models.DTOs.CreateDTOs
{
    public class CreateInvoicesDTO
    {
        [Required(ErrorMessage = "CustomerID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "CustomerID must be a positive number.")]
        public int? CustomerID { get; set; }
        [Required(ErrorMessage = "InvoiceDate is required.")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid date and time format for InvoiceDate.")]
        public DateTime? InvoiceDate { get; set; }
        [Required(ErrorMessage = "TotalAmount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "TotalAmount must be a positive value.")]
        public decimal? TotalAmount { get; set; }
        [Required(ErrorMessage = "PaymentStatus is required.")]
        [StringLength(50, ErrorMessage = "PaymentStatus cannot exceed 50 characters.")]
        public string? PaymentStatus { get; set; }
        [StringLength(2000, ErrorMessage = "Description cannot exceed 2000 characters.")]
        public string? Description { get; set; }
    }
}
