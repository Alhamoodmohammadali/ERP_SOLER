namespace ERP.API.BusinessLayer.Service.ServiceHRM
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        public EmployeeService(ILogger  logger, IUnitOfWork unitOfWork)
            : base(logger, unitOfWork)
        {
        }
        protected override async Task AddAsync(Employee entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Employee.AddAsync(entity);
        }
        protected override async Task UpdateAsync(Employee entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Employee.UpdateAsync(entity);
        }
        public override async Task DeleteInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Employee.DeleteAsync(id);
        }

        public override async Task<IEnumerable<Employee>> GetAllInternalAsync(string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.Employee.GetAllAsync();
        }

        public override async Task<Employee> GetByIdInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.Employee.GetByIdAsync(id);
        }
    }
}
