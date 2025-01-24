namespace ERP.API.BusinessLayer.Service.ServiceAddress
{
    public class AddressService : BaseService<Address>, IAddressService
    {
        public AddressService(ILogger  logger, IUnitOfWork unitOfWork)
            : base(logger, unitOfWork)
        {
        }

        protected override async Task AddAsync(Address entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Address.AddAsync(entity, TenantID, UserId);
        }

        protected override async Task UpdateAsync(Address entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Address.UpdateAsync(entity, TenantID, UserId);
        }

        public override async Task DeleteInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Address.DeleteAsync(id, TenantID, UserId);
        }

        public override async Task<IEnumerable<Address>> GetAllInternalAsync(string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.Address.GetAllAsync(TenantID, UserId);
        }

        public override async Task<Address> GetByIdInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.Address.GetByIdAsync(id, TenantID, UserId);
        }
    }
}
