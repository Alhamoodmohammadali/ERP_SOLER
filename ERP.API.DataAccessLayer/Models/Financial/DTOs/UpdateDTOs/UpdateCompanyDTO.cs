 
namespace ERP.API.DataAccessLayer.Models.Financial.DTOs.UpdateDTOs
{
    public class UpdateCompanyDTO : AnalysisSharedProperty
    {
        public string? CompanyName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int? AddressID { get; set; }
    }
}
