namespace ERP.API.BusinessLayer.Service
{
    public abstract class BaseService<T> : IBaseService<T> where T : class
    {
        protected readonly ILogger _logger;
        protected readonly IUnitOfWork _unitOfWork;
        public BaseService(ILogger logger, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<T> GetByIdAsync(int id, string? TenantID = null, string? UserId = null)
        {
            try
            {
                _logger.LogInformation($"Fetching entity of type {typeof(T).Name} with ID: {id}");
                return await GetByIdInternalAsync(id, TenantID, UserId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching entity of type {typeof(T).Name} with ID: {id}");
                throw;
            }
        }
        public async Task<IEnumerable<T>> GetAllAsync(string? TenantID = null, string? UserId = null)
        {
            try
            {
                _logger.LogInformation($"Fetching all entities of type {typeof(T).Name}");
                return await GetAllInternalAsync(TenantID, UserId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching all entities of type {typeof(T).Name}");
                throw;
            }
        }
        public async Task DeleteAsync(int id, string? TenantID = null, string? UserId = null)
        {
            try
            {
                _logger.LogInformation($"Deleting entity of type {typeof(T).Name} with ID: {id}");
                await DeleteInternalAsync(id);
                _logger.LogInformation($"Successfully deleted entity of type {typeof(T).Name} with ID: {id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while deleting entity of type {typeof(T).Name} with ID: {id}");
                throw;
            }
        }
        public async Task Save(T entity, int? id = null, string? TenantID = null, string? UserId = null)
        {
            try
            {
                if (id == null || id <= 0)
                {
                    _logger.LogInformation($"Adding new entity of type {typeof(T).Name}");
                    await AddAsync(entity, TenantID, UserId);
                    _logger.LogInformation($"Successfully added new entity of type {typeof(T).Name}");
                }
                else
                {
                    _logger.LogInformation($"Updating entity of type {typeof(T).Name} with ID: {id}");
                    await UpdateAsync(entity, TenantID, UserId);
                    _logger.LogInformation($"Successfully updated entity of type {typeof(T).Name} with ID: {id}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while saving entity of type {typeof(T).Name} with ID: {id}");
                throw;
            }
        }
        public abstract Task<T> GetByIdInternalAsync(int id, string? TenantID = null, string? UserId = null);
        public abstract Task<IEnumerable<T>> GetAllInternalAsync(string? TenantID = null, string? UserId = null);
        public abstract Task DeleteInternalAsync(int id, string? TenantID = null, string? UserId = null);
        protected abstract Task AddAsync(T entity, string? TenantID = null, string? UserId = null);
        protected abstract Task UpdateAsync(T entity, string? TenantID = null, string? UserId = null);
    }
}
