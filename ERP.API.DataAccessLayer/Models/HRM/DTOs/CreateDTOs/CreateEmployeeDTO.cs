namespace ERP.API.DataAccessLayer.Models.HRM.DTOs.CreateDTOs
{
    public class CreateEmployeeDTO : CreateUpdatePersonDTO
    {
        [Required(ErrorMessage = "Hire date is required.")]
        [DataType(DataType.Date)]
        public DateTime? HireDate { get; set; }
        [Required(ErrorMessage = "Job title is required.")]
        [StringLength(100, ErrorMessage = "Job title cannot exceed 100 characters.")]
        public string? JobTitle { get; set; }
        [Required(ErrorMessage = "Salary is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive value.")]
        public decimal? Salary { get; set; }
        [Required(ErrorMessage = "Department is required.")]
        [StringLength(100, ErrorMessage = "Department cannot exceed 100 characters.")]
        public string? Department { get; set; }

    }
}
