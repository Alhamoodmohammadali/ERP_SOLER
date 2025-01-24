namespace ERP.API.DataAccessLayer.Models.HRM.DTOs.CreateDTOs
{
    public class CreateCustomerDTO : CreateUpdatePersonDTO
    {
        [Required(ErrorMessage = "RegistrationDate is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime? RegistrationDate { get; set; }

        [Required(ErrorMessage = "PreferredContactMethod is required.")]
        [StringLength(50, ErrorMessage = "PreferredContactMethod cannot exceed 50 characters.")]
        [RegularExpression("^(Phone|Email)$", ErrorMessage = "PreferredContactMethod must be either 'Phone' or 'Email'.")]
        public string? PreferredContactMethod { get; set; }
        [Required(ErrorMessage = "IsVIP status is required.")]
        public bool? IsVIP { get; set; }
    }
}
