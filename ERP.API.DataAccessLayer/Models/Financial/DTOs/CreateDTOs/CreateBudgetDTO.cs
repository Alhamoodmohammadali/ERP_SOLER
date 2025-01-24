namespace ERP.API.DataAccessLayer.Models.Financial.DTOs.CreateDTOs
{
    public class CreateBudgetDTO
    {
        [Required(ErrorMessage = "Balance is required.")]
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "Balance must be a non-negative value.")]
        public decimal? Balance { get; set; }

        [Required(ErrorMessage = "TransactionType is required.")]
        [StringLength(10, ErrorMessage = "TransactionType can be a maximum of 10 characters.")]
        [RegularExpression("^(NotPaid|Paid)$", ErrorMessage = "Transaction Type must be either 'NotPaid' or 'Paid'.")]
        public string? TransactionType { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "Amount must be a positive value.")]
        public decimal? Amount { get; set; }

        [StringLength(255, ErrorMessage = "Description can be a maximum of 255 characters.")]
        public string? Description { get; set; }
        [Required]
        public DateTime? TransactionDate { get; set; } 
    }
}
