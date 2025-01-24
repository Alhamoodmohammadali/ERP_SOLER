namespace ERP.API.BusinessLayer.Service.IService
{
    public interface IBaseService<T> where T : class
    {
        Task<T> GetByIdAsync(int id, string? TenantID = null, string? UserId = null);
        Task<IEnumerable<T>> GetAllAsync(string? TenantID = null, string? UserId = null);
        Task Save(T entity, int? Id = null, string? TenantID = null, string? UserId = null);
        Task DeleteAsync(int id, string? TenantID = null, string? UserId = null);
    }
}
