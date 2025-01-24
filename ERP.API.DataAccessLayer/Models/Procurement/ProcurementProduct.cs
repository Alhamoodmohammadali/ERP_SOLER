namespace ERP.API.DataAccessLayer.Models.Procurement
{
    public class ProcurementProduct : Analysis
    {
        public int? ProcurementProductID { get; set; }
        public int? ProcurementID { get; set; }
        public int? ProductID { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public ProcurementProduct() : base()
        {
            ProcurementProductID = null;
            ProcurementID = null;
            ProductID = null;
            Quantity = null;
            UnitPrice = null;
            UnitPrice = null;
        }
    }
}
