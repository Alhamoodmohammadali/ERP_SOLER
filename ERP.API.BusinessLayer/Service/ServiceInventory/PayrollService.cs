
namespace ERP.API.BusinessLayer.Service
{
    public class PayrollService : BaseService<Payroll>, IPayrollService
    {
        public PayrollService(ILogger  logger, IUnitOfWork unitOfWork)
            : base(logger, unitOfWork)
        {
        }
        protected override async Task AddAsync(Payroll entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Payroll.AddAsync(entity);
        }
        protected override async Task UpdateAsync(Payroll entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Payroll.UpdateAsync(entity);
        }
        public override async Task DeleteInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Payroll.DeleteAsync(id);
        }
        public override async Task<IEnumerable<Payroll>> GetAllInternalAsync(string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.Payroll.GetAllAsync();
        }
        public override async Task<Payroll> GetByIdInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.Payroll.GetByIdAsync(id);
        }
    }
}
