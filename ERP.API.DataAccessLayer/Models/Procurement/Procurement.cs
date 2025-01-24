namespace ERP.API.DataAccessLayer.Models.Procurement
{
    public class Procurement : Analysis
    {
        public int? ProcurementID { get; set; }
        public int? SupplierID { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? PaymentMethod { get; set; }
        public string? ProcurementStatus { get; set; }
        public Procurement() : base()
        {
            ProcurementID = null;
            SupplierID = null;
            PurchaseDate = null;
            TotalAmount = null;
            PaymentMethod = null;
            ProcurementStatus = null;
        }
    }
}
