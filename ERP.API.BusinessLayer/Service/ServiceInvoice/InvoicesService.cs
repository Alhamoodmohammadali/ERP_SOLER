namespace ERP.API.BusinessLayer.Service.ServiceInvoice
{
    public class InvoicesService : BaseService<Invoice>, IInvoicesService
    {
        public InvoicesService(ILogger logger, IUnitOfWork unitOfWork)
            : base(logger, unitOfWork)
        {
        }

        protected override async Task AddAsync(Invoice entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Invoices.AddAsync(entity);
        }

        protected override async Task UpdateAsync(Invoice entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Invoices.UpdateAsync(entity);
        }

        public override async Task DeleteInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Invoices.DeleteAsync(id);
        }

        public override async Task<IEnumerable<Invoice>> GetAllInternalAsync(string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.Invoices.GetAllAsync();
        }

        public override async Task<Invoice> GetByIdInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.Invoices.GetByIdAsync(id);
        }
    }
}
