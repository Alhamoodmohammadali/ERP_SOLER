namespace ERP.API.DataAccessLayer.Models.Financial
{
    public class Budget : Analysis
    {
        public int? BudgetID { get; set; }
        public decimal? Balance { get; set; }
        public string? TransactionType { get; set; }
        public decimal? Amount { get; set; }
        public string? Description { get; set; }
        public DateTime? TransactionDate { get; set; }
        public Budget() : base()
        {
            BudgetID = null;
            Balance = null;
            TransactionType = null;
            Amount = null;
            Description = null;
            TransactionDate = null;
        }
    }
}
