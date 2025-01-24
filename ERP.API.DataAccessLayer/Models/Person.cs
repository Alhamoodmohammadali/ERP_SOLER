namespace ERP.API.DataAccessLayer.Models
{
    public abstract class Person :Analysis
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? Gender { get; set; }
        protected Person() :base() 
        {
            FirstName = null;
            LastName = null;
            Email = null;
            Phone = null;
            Address = null;
            DateOfBirth = null;
            Gender = false;
        }
    }
}
