namespace ERP.API.BusinessLayer.Service.ServiceWorkshop
{
    public class WorkshopEmployeeScheduleService : BaseService<WorkshopEmployeeSchedule>, IWorkshopEmployeeScheduleService
    {
        public WorkshopEmployeeScheduleService(ILogger logger, IUnitOfWork unitOfWork)
            : base(logger, unitOfWork)
        {
        }
        protected override async Task AddAsync(WorkshopEmployeeSchedule entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.WorkshopEmployeeSchedule.AddAsync(entity);
        }
        protected override async Task UpdateAsync(WorkshopEmployeeSchedule entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.WorkshopEmployeeSchedule.UpdateAsync(entity);
        }
        public override async Task DeleteInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.WorkshopEmployeeSchedule.DeleteAsync(id);
        }
        public override async Task<IEnumerable<WorkshopEmployeeSchedule>> GetAllInternalAsync(string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.WorkshopEmployeeSchedule.GetAllAsync();
        }
        public override async Task<WorkshopEmployeeSchedule> GetByIdInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.WorkshopEmployeeSchedule.GetByIdAsync(id);
        }
    }
}
