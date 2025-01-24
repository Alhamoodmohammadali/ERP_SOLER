using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.API.DataAccessLayer.Models.Product.DTOs.UpdateDTOs
{
    public class UpdateProductsDTO
    {
        [Required(ErrorMessage = "ProductID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "ProductID must be a positive number.")]
        public int? ProductID { get; set; }

        [StringLength(255, ErrorMessage = "ProductName cannot exceed 255 characters.")]
        public string? ProductName { get; set; }

        [StringLength(1000, ErrorMessage = "ProductDescription cannot exceed 1000 characters.")]
        public string? ProductDescription { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "CategoryID must be a positive number.")]
        public int? CategoryID { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public decimal? Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "QuantityAvailable must be a non-negative number.")]
        public int? QuantityAvailable { get; set; }

        [StringLength(100, ErrorMessage = "SKU cannot exceed 100 characters.")]
        public string? SKU { get; set; }

        public bool? IsActive { get; set; }
    }
}

