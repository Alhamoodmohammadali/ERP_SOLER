namespace ERP.API.DataAccessLayer.Models.HRM
{
    public class Customer : Person
    {
        public int? CustomerID { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string? PreferredContactMethod { get; set; }
        public bool? IsVIP { get; set; }
        public Customer() : base()
        {
            CustomerID = null;
            RegistrationDate = null;
            PreferredContactMethod = null;
            IsVIP = null;
        }
    }
}
