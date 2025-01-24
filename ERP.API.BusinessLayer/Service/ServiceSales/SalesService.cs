namespace ERP.API.BusinessLayer.Service.ServiceSales
{
    public class SalesService : BaseService<Sale>, ISalesService
    {
        public SalesService(ILogger logger, IUnitOfWork unitOfWork)
           : base(logger, unitOfWork)
        {
        }
        protected override async Task AddAsync(Sale entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.sales.AddAsync(entity);
        }
        protected override async Task UpdateAsync(Sale entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.sales.UpdateAsync(entity);
        }
        public override async Task DeleteInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.sales.DeleteAsync(id);
        }
        public override async Task<IEnumerable<Sale>> GetAllInternalAsync(string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.sales.GetAllAsync();
        }
        public override async Task<Sale> GetByIdInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.sales.GetByIdAsync(id);
        }
    }
}
