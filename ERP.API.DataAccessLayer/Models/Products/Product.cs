namespace ERP.API.DataAccessLayer.Models.Product
{
    public class Product : Analysis
    {
        public int? ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public int? CategoryID { get; set; }
        public decimal? Price { get; set; }
        public int? QuantityAvailable { get; set; }
        public string? SKU { get; set; }
        public bool? IsActive { get; set; }
        public int? QuantityInStock { get; set; }
        public Product() : base()
        {
            ProductID = null;
            ProductName = null;
            ProductDescription = null;
            CategoryID = null;
            Price = null;
            QuantityAvailable = null;
            SKU = null;
            IsActive = null;
        }
    }
}
