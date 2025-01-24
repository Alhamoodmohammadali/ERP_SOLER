namespace ERP.API.BusinessLayer.Service.ServiceFinancial
{
    public class BudgetService : BaseService<Budget>, IBudgetService
    {
        public BudgetService(ILogger logger, IUnitOfWork unitOfWork)
            : base(logger, unitOfWork)
        {
        }
        protected override async Task AddAsync(Budget entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Budget.AddAsync(entity, TenantID, UserId);
        }
        protected override async Task UpdateAsync(Budget entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Budget.UpdateAsync(entity, TenantID, UserId);
        }
        public override async Task DeleteInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Budget.DeleteAsync(id, TenantID, UserId);
        }
        public override async Task<IEnumerable<Budget>> GetAllInternalAsync(string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.Budget.GetAllAsync(TenantID, UserId);
        }
        public override async Task<Budget> GetByIdInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.Budget.GetByIdAsync(id, TenantID, UserId);
        }
    }
}
