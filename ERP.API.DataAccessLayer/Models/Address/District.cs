namespace ERP.API.DataAccessLayer.Models.Address
{
    public class District : Analysis
    {
        public int? DistrictID { get; set; }
        public string? DistrictName { get; set; }
        public int? CityID { get; set; }
        public District() : base()
        {
            this.DistrictID = null;
            this.DistrictName = null;
            this.CityID = null;

        }
    }
}
