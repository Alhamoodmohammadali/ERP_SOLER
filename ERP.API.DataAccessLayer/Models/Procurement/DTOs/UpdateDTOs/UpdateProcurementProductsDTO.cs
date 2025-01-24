namespace ERP.API.DataAccessLayer.Models.Procurement.DTOs.UpdateDTOs
{
    public class UpdateProcurementProductsDTO
    {
        [Required(ErrorMessage = "ProcurementProductID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "ProcurementProductID must be a positive number.")]
        public int? ProcurementProductID { get; set; }

        [Required(ErrorMessage = "ProcurementID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "ProcurementID must be a positive number.")]
        public int? ProcurementID { get; set; }

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
