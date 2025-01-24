
namespace ERP.API.BusinessLayer.Service.ServiceProcurement
{
    public class ProcurementProductsService : BaseService<ProcurementProduct>, IProcurementProductsService
    {
        public ProcurementProductsService(ILogger logger, IUnitOfWork unitOfWork)
            : base(logger, unitOfWork)
        {
        }

        protected override async Task AddAsync(ProcurementProduct entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.ProcurementProducts.AddAsync(entity);
        }

        protected override async Task UpdateAsync(ProcurementProduct entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.ProcurementProducts.UpdateAsync(entity);
        }

        public override async Task DeleteInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.ProcurementProducts.DeleteAsync(id);
        }

        public override async Task<IEnumerable<ProcurementProduct>> GetAllInternalAsync(string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.ProcurementProducts.GetAllAsync();
        }

        public override async Task<ProcurementProduct> GetByIdInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.ProcurementProducts.GetByIdAsync(id);
        }
    }
}
