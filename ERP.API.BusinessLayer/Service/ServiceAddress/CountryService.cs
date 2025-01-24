namespace ERP.API.BusinessLayer.Service.ServiceAddress
{
    public class CountryService : BaseService<Country>, ICountryService
    {
        public CountryService(ILogger logger, IUnitOfWork unitOfWork) : base(logger, unitOfWork)
        {
        }
        protected override async Task AddAsync(Country entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Country.AddAsync(entity, TenantID, UserId);
        }
        protected override async Task UpdateAsync(Country entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Country.UpdateAsync(entity, TenantID, UserId);
        }
        public override async Task DeleteInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Country.DeleteAsync(id, TenantID, UserId);
        }
        public override async Task<IEnumerable<Country>> GetAllInternalAsync(string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.Country.GetAllAsync(TenantID, UserId);
        }
        public override async Task<Country> GetByIdInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.Country.GetByIdAsync(id, TenantID, UserId);
        }
    }
}
