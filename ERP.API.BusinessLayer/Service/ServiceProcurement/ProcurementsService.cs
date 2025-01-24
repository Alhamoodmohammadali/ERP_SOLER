namespace ERP.API.BusinessLayer.Service.ServiceProcurement
{
    public class ProcurementsService : BaseService<Procurement>, IProcurementsService
    {
        public ProcurementsService(ILogger logger, IUnitOfWork unitOfWork)
            : base(logger, unitOfWork)
        {
        }
        protected override async Task AddAsync(Procurement entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Procurements.AddAsync(entity);
        }
        protected override async Task UpdateAsync(Procurement entity, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Procurements.UpdateAsync(entity);
        }
        public override async Task DeleteInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            await _unitOfWork.Procurements.DeleteAsync(id);
        }
        public override async Task<IEnumerable<Procurement>> GetAllInternalAsync(string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.Procurements.GetAllAsync();
        }
        public override async Task<Procurement> GetByIdInternalAsync(int id, string? TenantID = null, string? UserId = null)
        {
            return await _unitOfWork.Procurements.GetByIdAsync(id);
        }
    }
}
