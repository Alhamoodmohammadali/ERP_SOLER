namespace ERP.API.BusinessLayer.Service
{
    public class EmployeeAttendanceService : BaseService<EmployeeAttendance>, IEmployeeAttendanceService
    {
        public EmployeeAttendanceService(ILogger logger, IUnitOfWork unitOfWork)
            : base(logger, unitOfWork)
        {
        }
        protected override async Task AddAsync(EmployeeAttendance entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.EmployeeAttendance.AddAsync(entity);
        }
        protected override async Task UpdateAsync(EmployeeAttendance entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.EmployeeAttendance.UpdateAsync(entity);
        }

        public override async Task DeleteInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.EmployeeAttendance.DeleteAsync(id);
        }

        public override async Task<IEnumerable<EmployeeAttendance>> GetAllInternalAsync(string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.EmployeeAttendance.GetAllAsync();
        }

        public override async Task<EmployeeAttendance> GetByIdInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.EmployeeAttendance.GetByIdAsync(id);
        }
    }
}
