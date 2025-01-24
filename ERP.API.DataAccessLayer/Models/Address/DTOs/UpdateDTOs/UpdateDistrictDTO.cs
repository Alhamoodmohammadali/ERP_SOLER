namespace ERP.API.DataAccessLayer.Models.Address.DTOs.UpdateDTOs
{
    public class UpdateDistrictDTO
    {
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }
        public int? CityID { get; set; }
        public string Id { get; set; }
    }
}
