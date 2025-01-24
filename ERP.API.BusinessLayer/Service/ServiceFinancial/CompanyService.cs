namespace ERP.API.BusinessLayer.Service.ServiceFinancial
{
    public class CompanyService : BaseService<Company>, ICompanyService
    {
        public CompanyService(ILogger logger, IUnitOfWork unitOfWork) : base(logger, unitOfWork)
        {
        }
        protected override async Task AddAsync(Company entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Company.AddAsync(entity, TenantID, UserId);
        }

        protected override async Task UpdateAsync(Company entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Company.UpdateAsync(entity, TenantID, UserId);
        }

        public override async Task DeleteInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Company.DeleteAsync(id, TenantID, UserId);
        }

        public override async Task<IEnumerable<Company>> GetAllInternalAsync(string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.Company.GetAllAsync(TenantID, UserId);
        }

        public override async Task<Company> GetByIdInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.Company.GetByIdAsync(id, TenantID, UserId);
        }
    }
}
