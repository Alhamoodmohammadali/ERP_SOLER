 

namespace ERP.API.DataAccessLayer.Models.Financial.DTOs.CreateDTOs
{
    public class CreateCompanyDTO 
    {
        public string? CompanyName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int? AddressID { get; set; }

    }
}
