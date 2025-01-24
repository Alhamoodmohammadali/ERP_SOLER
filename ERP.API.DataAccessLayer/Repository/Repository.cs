namespace ERP.API.DataAccessLayer.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly string _connectionString;

        public Repository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync(string? TenantID = null, string? UserId = null)
        {
            var entities = new List<T>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("SP_GetAll" + typeof(T).Name + "s", connection);
                command.CommandType = CommandType.StoredProcedure;

                // إضافة TenantID و UserId كمعلمات باستخدام الدالة المشتركة
                AddCommonParameters(command, TenantID, UserId);
                  
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        T entity = Map(reader);
                        entities.Add(entity);
                    }
                }
            }
            return entities;
        }
        public virtual async Task<T> GetByIdAsync(int id, string? TenantID = null, string? UserId = null)
        {
            T entity = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("SP_Get" + typeof(T).Name + "ById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@" + typeof(T).Name.Trim() + "ID", id);

                // إضافة TenantID و UserId كمعلمات باستخدام الدالة المشتركة
                AddCommonParameters(command, TenantID, UserId);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        entity = Map(reader);
                    }
                }
            }

            return entity;
        }

        public virtual async Task<int> AddAsync(T entity, string? TenantID = null, string? UserId = null)
        {
            int generatedId;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("SP_Create" + typeof(T).Name.Trim(), connection);
                command.CommandType = CommandType.StoredProcedure;

                // إضافة المعلمات الخاصة بالكيان
                AddParameters(command, entity);

                // إضافة TenantID و UserId كمعلمات باستخدام الدالة المشتركة
                AddCommonParameters(command, TenantID, UserId);

                // إضافة معلمة الإخراج لإرجاع ID الجديد
           
                
                
                SqlParameter outputIdParam = new SqlParameter(typeof(T).Name.Trim() + "ID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                command.Parameters.Add(outputIdParam);

                await command.ExecuteNonQueryAsync();
                generatedId = (int)outputIdParam.Value;
            }

            return generatedId;
        }

        public virtual async Task UpdateAsync(T entity, string? TenantID = null, string? UserId = null)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("SP_Update" + typeof(T).Name.Trim(), connection);
                command.CommandType = CommandType.StoredProcedure;

                // إضافة المعلمات الخاصة بالكيان
                AddParameters(command, entity);

                // إضافة TenantID و UserId كمعلمات باستخدام الدالة المشتركة
                AddCommonParameters(command, TenantID, UserId);

                await command.ExecuteNonQueryAsync();
            }
        }

        public virtual async Task DeleteAsync(int id, string? TenantID = null, string? UserId = null)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("SP_Delete" + typeof(T).Name.Trim(), connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@" + typeof(T).Name.Trim() + "ID", id);

                // إضافة TenantID و UserId كمعلمات باستخدام الدالة المشتركة
                AddCommonParameters(command, TenantID, UserId);

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<IEnumerable<T>> ExecuteStoredProcedureAsync(string storedProcedureName, params object[] parameters)
        {
            var entities = new List<T>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand(storedProcedureName, connection);
                command.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        command.Parameters.Add(parameters[i]);
                    }
                }

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        T entity = Map(reader);
                        entities.Add(entity);
                    }
                }
            }

            return entities;
        }

        // دالة لإضافة المعلمات المشتركة TenantID و UserId
        private void AddCommonParameters(SqlCommand command, string? TenantID, string? UserId)
        {
            command.Parameters.AddWithValue("@TenantID", (object?)TenantID ?? DBNull.Value);
            command.Parameters.AddWithValue("@UserId", (object?)UserId ?? DBNull.Value);
        }

        protected abstract T Map(SqlDataReader reader);
        protected abstract void AddParameters(SqlCommand command, T entity);
    }
}

 