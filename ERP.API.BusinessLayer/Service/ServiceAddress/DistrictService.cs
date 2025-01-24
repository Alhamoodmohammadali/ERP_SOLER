namespace ERP.API.BusinessLayer.Service.ServiceAddress
{
    public class DistrictService : BaseService<District>, IDistrictService
    {
        public DistrictService(ILogger logger, IUnitOfWork unitOfWork) : base(logger, unitOfWork)
        {
        }
        protected override async Task AddAsync(District entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.District.AddAsync(entity, TenantID, UserId);
        }
        protected override async Task UpdateAsync(District entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.District.UpdateAsync(entity, TenantID, UserId);
        }
        public override async Task DeleteInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.District.DeleteAsync(id, TenantID, UserId);
        }
        public override async Task<IEnumerable<District>> GetAllInternalAsync(string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.District.GetAllAsync(TenantID, UserId);
        }

        public override async Task<District> GetByIdInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.District.GetByIdAsync(id, TenantID, UserId);
        }
    }
}
