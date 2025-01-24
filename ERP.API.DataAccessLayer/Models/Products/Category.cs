namespace ERP.API.DataAccessLayer.Models.Products.Product
{
    public class Category : Analysis
    {
        public int? CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public bool? IsActive { get; set; }
        public Category() : base()
        {
            CategoryID = null;
            CategoryName = null;
            CategoryDescription = null;
            IsActive = null;
        }
    }
}
