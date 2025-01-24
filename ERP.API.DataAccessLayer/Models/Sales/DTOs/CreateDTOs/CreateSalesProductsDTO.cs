namespace ERP.API.DataAccessLayer.Models.Sales.DTOs.CreateDTOs
{
    public class CreateSalesProductsDTO
    {
        [Required(ErrorMessage = "SaleID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "SaleID must be a positive number.")]
        public int? SaleID { get; set; }

        [Required(ErrorMessage = "ProductID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "ProductID must be a positive number.")]
        public int? ProductID { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive number.")]
        public int? Quantity { get; set; }

        [Required(ErrorMessage = "UnitPrice is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "UnitPrice must be a positive value.")]
        public decimal? UnitPrice { get; set; }
    }
}
