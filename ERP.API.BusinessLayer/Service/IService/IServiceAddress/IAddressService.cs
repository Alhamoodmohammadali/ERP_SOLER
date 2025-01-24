
namespace ERP.API.BusinessLayer.Service.IService.IServiceAddress
{
    public interface IAddressService : IBaseService<Address>
    {
        Task<Address> GetByIdInternalAsync(int id, string? TenantID = null, string? UserId = null);
    }
}
