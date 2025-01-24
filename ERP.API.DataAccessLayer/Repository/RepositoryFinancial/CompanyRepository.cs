namespace ERP.API.DataAccessLayer.Repository.RepositoryFinancial
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(string connectionString) : base(connectionString)
        {
        }

        public override async Task<IEnumerable<Company>> GetAllAsync(string? TenantID = null, string? UserId = null)
        {
            var entities = new List<Company>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand("SP_GetAllCompanys", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // إضافة UserId كمعامل
                    command.Parameters.AddWithValue("@UserId", (object?)UserId ?? DBNull.Value);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            // قراءة البيانات من SqlDataReader وتخزينها في كائن Company
                            var company = new Company
                            {
                                TenantID = reader["TenantID"] as string,
                                CompanyName = reader["CompanyName"] as string,
                                Email = reader["Email"] as string,
                                PhoneNumber = reader["PhoneNumber"] as string,
                                AddressID = reader["AddressID"] != DBNull.Value ? (int?)reader["AddressID"] : null,
                                CreatedAt = reader["CreatedAt"] != DBNull.Value ? (DateTime?)reader["CreatedAt"] : null,
                                UpdatedAt = reader["UpdatedAt"] != DBNull.Value ? (DateTime?)reader["UpdatedAt"] : null
                            };
                            entities.Add(company);
                        }
                    }
                }
            }

            return entities;
        }



        public override async Task<int> AddAsync(Company entity, string? TenantID = null, string? UserId = null)
        {
            int generatedId;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("SP_CreateCompany", connection);
                command.CommandType = CommandType.StoredProcedure;

                AddParameters(command, entity);
                command.Parameters.AddWithValue("@UserId", (object?)UserId ?? DBNull.Value);

                SqlParameter outputIdParam = new SqlParameter("TenantID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                command.Parameters.Add(outputIdParam);

                await command.ExecuteNonQueryAsync();
                generatedId = (int)outputIdParam.Value;
            }

            return generatedId;
        }



        public override async Task<Company> GetByIdAsync(int id, string? TenantID = null, string? UserId = null)
        {
            Company entity = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("SP_GetCompanyById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserId", (object?)UserId ?? DBNull.Value);
                command.Parameters.AddWithValue("@TenantID", (object?)TenantID ?? DBNull.Value);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        entity = new Company
                        {
                            CompanyName = reader["CompanyName"] as string,
                            Email = reader["Email"] as string,
                            PhoneNumber = reader["PhoneNumber"] as string,
                            AddressID = reader["AddressID"] != DBNull.Value ? (int?)reader["AddressID"] : null,
                            CreatedAt = reader["CreatedAt"] != DBNull.Value ? (DateTime?)reader["CreatedAt"] : null,
                            UpdatedAt = reader["UpdatedAt"] != DBNull.Value ? (DateTime?)reader["UpdatedAt"] : null
                        };
                    }

                }
            }

            return entity;
        }


        protected override void AddParameters(SqlCommand command, Company entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            command.Parameters.AddWithValue("@CompanyName", entity.CompanyName ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Email", entity.Email ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@PhoneNumber", entity.PhoneNumber ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@AddressID", entity.AddressID ?? (object)DBNull.Value);
        }
        protected override Company Map(SqlDataReader reader)
        {
            return new Company
            {
                CompanyName = reader["CompanyName"] as string,
                Email = reader["Email"] as string,
                PhoneNumber = reader["PhoneNumber"] as string,
                AddressID = reader["AddressID"] as int?,
                CreatedAt = reader["CreatedAt"] as DateTime?,  // Mapped from Analysis
                UpdatedAt = reader["UpdatedAt"] as DateTime?   // Mapped from Analysis
            };
        }
    }
}
