namespace ERP.API.DataAccessLayer.Models.Address
{
    public class City : Analysis
    {
        public int? CityID { get; set; }
        public string? CityName { get; set; }
        public int? CountryID { get; set; }
        public City() : base()
        {
            this.CityID = null;
            this.CityName = null;
            this.CountryID = null;

        }
    }
}
