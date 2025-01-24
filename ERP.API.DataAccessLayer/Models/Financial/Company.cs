namespace ERP.API.DataAccessLayer.Models.Financial
{
    public class Company : Analysis
    {
        public string? CompanyName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int? AddressID { get; set; }
        public Company() : base()
        {
            this.CompanyName = null;
            this.Email = null;
            this.PhoneNumber = null;
            this.AddressID = null;
        }
    }
}
