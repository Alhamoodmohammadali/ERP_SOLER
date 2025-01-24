
namespace ERP.API.BusinessLayer.Service.ServiceProductManagement
{
    public class ProductsService : BaseService<Product>, IProductsService
    {
        public ProductsService(ILogger  logger, IUnitOfWork unitOfWork)
            : base(logger, unitOfWork)
        {
        }

        protected override async Task AddAsync(Product entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Products.AddAsync(entity);
        }

        protected override async Task UpdateAsync(Product entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Products.UpdateAsync(entity);
        }

        public override async Task DeleteInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Products.DeleteAsync(id);
        }

        public override async Task<IEnumerable<Product>> GetAllInternalAsync(string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.Products.GetAllAsync();
        }

        public override async Task<Product> GetByIdInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.Products.GetByIdAsync(id);
        }
    }
}
