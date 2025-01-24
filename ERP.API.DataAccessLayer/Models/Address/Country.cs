namespace ERP.API.DataAccessLayer.Models.Address
{
    public class Country : Analysis
    {
        public int? CountryID { get; set; }
        public string? CountryName { get; set; }
        public Country() : base()
        {
            this.CountryID = null;
            this.CountryName = null;
                
        }
    }
}
