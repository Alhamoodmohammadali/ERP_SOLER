namespace ERP.API.DataAccessLayer.Models.Product.DTOs.UpdateDTOs
{
    public class UpdateCategoryDTO
    {
        [Required(ErrorMessage = "CategoryID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "CategoryID must be a positive number.")]
        public int? CategoryID { get; set; }

        [Required(ErrorMessage = "Category Name is required.")]
        [StringLength(255, ErrorMessage = "CategoryName cannot exceed 255 characters.")]
        public string? CategoryName { get; set; }

        [StringLength(1000, ErrorMessage = "CategoryDescription cannot exceed 1000 characters.")]
        public string? CategoryDescription { get; set; }

        public bool? IsActive { get; set; }
    }
}
