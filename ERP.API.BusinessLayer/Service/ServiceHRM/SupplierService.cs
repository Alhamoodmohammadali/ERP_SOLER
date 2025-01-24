namespace ERP.API.BusinessLayer.Service
{
    public class SupplierService : BaseService<Supplier>, ISupplierService
    {
        public SupplierService(ILogger  logger, IUnitOfWork unitOfWork)
            : base(logger, unitOfWork)
        {
        }

        protected override async Task AddAsync(Supplier entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Supplier.AddAsync(entity);
        }

        protected override async Task UpdateAsync(Supplier entity, string? TenantID = null, string? UserId = null)  
        {
            await _unitOfWork.Supplier.UpdateAsync(entity);
        }

        public override async Task DeleteInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Supplier.DeleteAsync(id);
        }

        public override async Task<IEnumerable<Supplier>> GetAllInternalAsync(string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.Supplier.GetAllAsync();
        }

        public override async Task<Supplier> GetByIdInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.Supplier.GetByIdAsync(id);
        }
    }
}
