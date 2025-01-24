namespace ERP.API.DataAccessLayer.Models.Invoice
{
    public class Invoice : Analysis
    {
        public int? InvoiceID { get; set; }
        public int? CustomerID { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? PaymentStatus { get; set; }
        public string? Description { get; set; }
        public Invoice() : base()
        {
            InvoiceID = null;
            CustomerID = null;
            InvoiceDate = null;
            TotalAmount = null;
            PaymentStatus = null;
            Description = null;
        }
    }
}
