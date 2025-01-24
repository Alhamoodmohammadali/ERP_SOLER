namespace ERP.API.DataAccessLayer.Models.Address
{
    public class Address : Analysis 
    {
        public int? AddressID { get; set; }
        public int? DistrictID { get; set; }
        public string? StreetName { get; set; }
        public string? BuildingNumber { get; set; }
        public string? PropertyNumber { get; set; }
        public Address() : base()
        {
            this.AddressID = null;
            this.DistrictID = null;
            this.StreetName = null;
            this.BuildingNumber = null;
            this.PropertyNumber = null;
        }
    }
}
