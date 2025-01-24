namespace ERP.API.DataAccessLayer.Models.Products.DTOs.CreateDTOs
{
    public class CreateCategoryDTO
    {
        [Required(ErrorMessage = "Category Name is required.")]
        [StringLength(255, ErrorMessage = "CategoryName cannot exceed 255 characters.")]
        public string? CategoryName { get; set; }

        [StringLength(1000, ErrorMessage = "CategoryDescription cannot exceed 1000 characters.")]
        public string? CategoryDescription { get; set; }
        public bool? IsActive { get; set; }
    }
}
