namespace ERP.API.DataAccessLayer.Models.HRM
{
    public class Supplier : Person
    {
        public int? SupplierID { get; set; }
        public string? CompanyName { get; set; }
        public string? SupplyType { get; set; }
        public DateTime? ContractStartDate { get; set; }
        public Supplier() : base()
        {
            SupplierID = null;
            CompanyName = null;
            SupplyType = null;
            ContractStartDate = null;
        }
    }
}
