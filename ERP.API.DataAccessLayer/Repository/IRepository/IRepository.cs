namespace ERP.API.DataAccessLayer.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(string? TenantID = null, string? UserId = null);
        Task<T> GetByIdAsync(int id, string? TenantID = null, string? UserId = null);
        Task<int> AddAsync(T entity, string? TenantID = null, string? UserId = null);
        Task UpdateAsync(T entity, string? TenantID = null, string? UserId = null);
        Task DeleteAsync(int id, string? TenantID = null, string? UserId = null);
        Task<IEnumerable<T>> ExecuteStoredProcedureAsync(string storedProcedureName, params object[] parameters);
    }
}
