
namespace ERP.API.BusinessLayer.Service.ServiceProductManagement
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        public CategoryService(ILogger  logger, IUnitOfWork unitOfWork)
            : base(logger, unitOfWork)
        {
        }

        protected override async Task AddAsync(Category entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Category.AddAsync(entity);
        }

        protected override async Task UpdateAsync(Category entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Category.UpdateAsync(entity);
        }

        public override async Task DeleteInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Category.DeleteAsync(id);
        }

        public override async Task<IEnumerable<Category>> GetAllInternalAsync(string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.Category.GetAllAsync();
        }

        public override async Task<Category> GetByIdInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.Category.GetByIdAsync(id);
        }
    }
}
