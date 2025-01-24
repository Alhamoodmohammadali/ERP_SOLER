namespace ERP.API.DataAccessLayer.Models.HRM.DTOs.CreateDTOs
{
    public class CreateSupplierDTO
    {
        [Required(ErrorMessage = "CompanyName is required.")]
        [StringLength(255, ErrorMessage = "CompanyName cannot exceed 255 characters.")]
        public string? CompanyName { get; set; }

        [Required(ErrorMessage = "SupplyType is required.")]
        [StringLength(100, ErrorMessage = "SupplyType cannot exceed 100 characters.")]
        public string? SupplyType { get; set; }

        [Required(ErrorMessage = "ContractStartDate is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format for ContractStartDate.")]
        public DateTime? ContractStartDate { get; set; }
    }
}
