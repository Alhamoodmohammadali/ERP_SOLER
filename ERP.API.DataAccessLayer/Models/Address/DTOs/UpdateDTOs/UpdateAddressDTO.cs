 
namespace ERP.API.DataAccessLayer.Models.Address.DTOs.UpdateDTOs
{
    public class UpdateAddressDTO
    {
        public int AddressID { get; set; }
        public int? DistrictID { get; set; }
        public string StreetName { get; set; }
        public string BuildingNumber { get; set; }
        public string PropertyNumber { get; set; }
        public string Id { get; set; }
    }
}
