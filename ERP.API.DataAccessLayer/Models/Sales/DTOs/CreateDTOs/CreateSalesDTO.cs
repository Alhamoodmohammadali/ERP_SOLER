namespace ERP.API.DataAccessLayer.Models.Sales.DTOs.CreateDTOs
{
    public class CreateSalesDTO
    {
        [Required(ErrorMessage = "CustomerID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "CustomerID must be a positive number.")]
        public int? CustomerID { get; set; }

        [Required(ErrorMessage = "SaleDate is required.")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid date format for SaleDate.")]
        public DateTime? SaleDate { get; set; }

        [Required(ErrorMessage = "TotalAmount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "TotalAmount must be a positive value.")]
        public decimal? TotalAmount { get; set; }

        [Required(ErrorMessage = "PaymentMethod is required.")]
        [StringLength(50, ErrorMessage = "PaymentMethod cannot exceed 50 characters.")]
        public string? PaymentMethod { get; set; }

        [Required(ErrorMessage = "SaleStatus is required.")]
        [StringLength(50, ErrorMessage = "SaleStatus cannot exceed 50 characters.")]
        public string? SaleStatus { get; set; }
    }
}
