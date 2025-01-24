namespace ERP.API.DataAccessLayer.Models.Workshop.DTOs.UpdateDTOs
{
    public class UpdateWorkshopDTO
    {
        [Required(ErrorMessage = "WorkshopID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "WorkshopID must be a positive number.")]
        public int? WorkshopID { get; set; }

        [Required(ErrorMessage = "CustomerID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "CustomerID must be a positive number.")]
        public int? CustomerID { get; set; }

        [Required(ErrorMessage = "WorkshopName is required.")]
        [StringLength(255, ErrorMessage = "WorkshopName cannot exceed 255 characters.")]
        public string? WorkshopName { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        [StringLength(255, ErrorMessage = "Location cannot exceed 255 characters.")]
        public string? Location { get; set; }

        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "StartDate is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format for StartDate.")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "EndDate is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format for EndDate.")]
        public DateTime? EndDate { get; set; }
    }
}
