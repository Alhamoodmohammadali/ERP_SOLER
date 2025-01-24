namespace ERP.API.DataAccessLayer.Repository.RepositoryHRM
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(string connectionString) : base(connectionString)
        {
        }
        protected override Customer Map(SqlDataReader reader)
        {
            return new Customer
            {
                CustomerID = reader["CustomerID"] as int?,
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                Email = reader["Email"].ToString(),
                Phone = reader["Phone"].ToString(),
                Address = reader["Address"].ToString(),
                DateOfBirth = reader["DateOfBirth"] as DateTime?,
                Gender = reader["Gender"] as bool?,
                RegistrationDate = reader["RegistrationDate"] as DateTime?,
                PreferredContactMethod = reader["PreferredContactMethod"].ToString(),
                IsVIP = reader["IsVIP"] as bool?,
            };
        }


        protected override void AddParameters(SqlCommand command, Customer entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            if (!(entity.CustomerID == null || entity.CustomerID <= 0))
            {

                command.Parameters.AddWithValue("@CustomerID", entity.CustomerID ?? (object)DBNull.Value);
            }

            command.Parameters.AddWithValue("@FirstName", entity.FirstName ?? (object)DBNull.Value);

            command.Parameters.AddWithValue("@LastName", entity.LastName ?? (object)DBNull.Value);

            command.Parameters.AddWithValue("@Email", entity.Email ?? (object)DBNull.Value);

            command.Parameters.AddWithValue("@Phone", entity.Phone ?? (object)DBNull.Value);

            command.Parameters.AddWithValue("@Address", entity.Address ?? (object)DBNull.Value);

            command.Parameters.AddWithValue("@DateOfBirth", entity.DateOfBirth ?? (object)DBNull.Value);

            command.Parameters.AddWithValue("@Gender", entity.Gender.HasValue ? entity.Gender.Value ? 1 : 0 : DBNull.Value); // Mapping bool? to BIT

            command.Parameters.AddWithValue("@RegistrationDate", entity.RegistrationDate ?? (object)DBNull.Value);

            command.Parameters.AddWithValue("@PreferredContactMethod", entity.PreferredContactMethod ?? (object)DBNull.Value);

            command.Parameters.AddWithValue("@IsVIP", entity.IsVIP.HasValue ? entity.IsVIP.Value ? 1 : 0 : DBNull.Value); // Mapping bool? to BIT
        }
    }
}
