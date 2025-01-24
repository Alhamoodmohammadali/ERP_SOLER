namespace ERP.API.DataAccessLayer.Repository.RepositoryHRM
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(string connectionString) : base(connectionString)
        {
        }
        protected override void AddParameters(SqlCommand command, Supplier entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            command.Parameters.AddWithValue("@SupplierID", entity.SupplierID ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CompanyName", entity.CompanyName ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@SupplyType", entity.SupplyType ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ContractStartDate", entity.ContractStartDate ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@FirstName", entity.FirstName ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@LastName", entity.LastName ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Email", entity.Email ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Phone", entity.Phone ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Address", entity.Address ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@DateOfBirth", entity.DateOfBirth ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Gender", entity.Gender ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CreatedAt", entity.CreatedAt ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@UpdatedAt", entity.UpdatedAt ?? (object)DBNull.Value);
        }
        protected override Supplier Map(SqlDataReader reader)
        {
            return new Supplier
            {
                SupplierID = reader["@SupplierID"] as int?,
                CompanyName = reader["@CompanyName"].ToString(),
                SupplyType = reader["@SupplyType"].ToString(),
                ContractStartDate = reader["@ContractStartDate"] as DateTime?,
                FirstName = reader["@FirstName"].ToString(),
                LastName = reader["@LastName"].ToString(),
                Email = reader["@Email"].ToString(),
                Phone = reader["@Phone"].ToString(),
                Address = reader["@Address"].ToString(),
                DateOfBirth = reader["@DateOfBirth"] as DateTime?,
                Gender = reader["@Gender"] as bool?,
                CreatedAt = reader["@CreatedAt"] as DateTime?,
                UpdatedAt = reader["@UpdatedAt"] as DateTime?
            };
        }
    }
}
