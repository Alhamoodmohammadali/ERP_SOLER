
namespace ERP.API.BusinessLayer.Service.ServiceSales
{
    public class SalesProductsService : BaseService<SalesProduct>, ISalesProductsService
    {
        public SalesProductsService(ILogger logger, IUnitOfWork unitOfWork)
            : base(logger, unitOfWork)
        {
        }

        protected override async Task AddAsync(SalesProduct entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.SalesProducts.AddAsync(entity);
        }

        protected override async Task UpdateAsync(SalesProduct entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.SalesProducts.UpdateAsync(entity);
        }

        public override async Task DeleteInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.SalesProducts.DeleteAsync(id);
        }

        public override async Task<IEnumerable<SalesProduct>> GetAllInternalAsync(string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.SalesProducts.GetAllAsync();
        }

        public override async Task<SalesProduct> GetByIdInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.SalesProducts.GetByIdAsync(id);
        }
    }
}
