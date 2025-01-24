
namespace ERP.API.BusinessLayer.Service.ServiceWorkshop
{
    public class WorkshopService : BaseService<Workshop>, IWorkshopService
    {
        public WorkshopService(ILogger  logger, IUnitOfWork unitOfWork)
            : base(logger, unitOfWork)
        {
        }

        protected override async Task AddAsync(Workshop entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Workshop.AddAsync(entity);
        }

        protected override async Task UpdateAsync(Workshop entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Workshop.UpdateAsync(entity);
        }

        public override async Task DeleteInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Workshop.DeleteAsync(id);
        }

        public override async Task<IEnumerable<Workshop>> GetAllInternalAsync(string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.Workshop.GetAllAsync();
        }

        public override async Task<Workshop> GetByIdInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.Workshop.GetByIdAsync(id);
        }
    }
}
