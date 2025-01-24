
namespace ERP.API.BusinessLayer.Service.ServiceHRM
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        public CustomerService(ILogger logger, IUnitOfWork unitOfWork)
            : base(logger, unitOfWork)
        {
        }

        protected override async Task AddAsync(Customer entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Customer.AddAsync(entity);
        }

        protected override async Task UpdateAsync(Customer entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Customer.UpdateAsync(entity);
        }

        public override async Task DeleteInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Customer.DeleteAsync(id);
        }

        public override async Task<IEnumerable<Customer>> GetAllInternalAsync(string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.Customer.GetAllAsync();
        }

        public override async Task<Customer> GetByIdInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.Customer.GetByIdAsync(id);
        }
    }
}
