namespace ERP.API.DataAccessLayer.Models.Sales
{
    public class SalesProduct : Analysis
    {
        public int? SaleProductID { get; set; }
        public int? SaleID { get; set; }
        public int? ProductID { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public SalesProduct() : base()
        {
            SaleProductID = null;
            SaleID = null;
            ProductID = null;
            Quantity = null;
            UnitPrice = null;
        }
    }
}
