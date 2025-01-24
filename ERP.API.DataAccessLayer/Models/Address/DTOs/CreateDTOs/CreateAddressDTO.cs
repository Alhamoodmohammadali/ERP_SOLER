namespace ERP.API.DataAccessLayer.Models.Address.DTOs.CreateDTOs
{
    public class CreateAddressDTO
    {
        public int? DistrictID { get; set; }
        public string StreetName { get; set; }
        public string BuildingNumber { get; set; }
        public string PropertyNumber { get; set; }
        public string Id { get; set; }
    }
}
