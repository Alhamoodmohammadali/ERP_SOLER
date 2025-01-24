namespace ERP.API.BusinessLayer.Service.ServiceAddress
{
    public class CityService : BaseService<City>, ICityService
    {
        public CityService(ILogger logger, IUnitOfWork unitOfWork)
            : base(logger, unitOfWork)
        {
        }

        protected override async Task AddAsync(City entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.City.AddAsync(entity, TenantID, UserId);
        }

        protected override async Task UpdateAsync(City entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.City.UpdateAsync(entity, TenantID, UserId);
        }

        public override async Task DeleteInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.City.DeleteAsync(id, TenantID, UserId);
        }

        public override async Task<IEnumerable<City>> GetAllInternalAsync(string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.City.GetAllAsync(TenantID, UserId);
        }

        public override async Task<City> GetByIdInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.City.GetByIdAsync(id, TenantID, UserId);
        }
    }
}
