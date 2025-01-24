namespace ERP.API.DataAccessLayer.Models.Sales
{
    public class Sale : Analysis
    {
        public int? SaleID { get; set; }
        public int? CustomerID { get; set; }
        public DateTime? SaleDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? PaymentMethod { get; set; }
        public string? SaleStatus { get; set; }

        public Sale() : base()
        {
            SaleID = null;
            CustomerID = null;
            SaleDate = null;
            TotalAmount = null;
            PaymentMethod = null;
            SaleStatus = null;
        }
    }
}
