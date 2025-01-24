
namespace ERP.API.BusinessLayer.Service.ServiceMaintenance
{
    public class MaintenanceOperationService : BaseService<MaintenanceOperation>, IMaintenanceOperationService
    {
        public MaintenanceOperationService(ILogger logger, IUnitOfWork unitOfWork)
            : base(logger, unitOfWork)
        {
        }

        protected override async Task AddAsync(MaintenanceOperation entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.MaintenanceOperation.AddAsync(entity);
        }

        protected override async Task UpdateAsync(MaintenanceOperation entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.MaintenanceOperation.UpdateAsync(entity);
        }

        public override async Task DeleteInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.MaintenanceOperation.DeleteAsync(id);
        }

        public override async Task<IEnumerable<MaintenanceOperation>> GetAllInternalAsync(string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.MaintenanceOperation.GetAllAsync();
        }

        public override async Task<MaintenanceOperation> GetByIdInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.MaintenanceOperation.GetByIdAsync(id);
        }
    }
}
