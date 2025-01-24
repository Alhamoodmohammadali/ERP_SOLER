namespace ERP.API.DataAccessLayer.Repository.RepositoryHRM
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(string connectionString) : base(connectionString)
        {
        }

        protected override void AddParameters(SqlCommand command, Employee entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            if (!(entity.EmployeeID == 0 || entity.EmployeeID == null))
            {
                command.Parameters.AddWithValue("@EmployeeID", entity.EmployeeID ?? (object)DBNull.Value);
            }
            command.Parameters.AddWithValue("@FirstName", entity.FirstName ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@LastName", entity.LastName ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Email", entity.Email ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Phone", entity.Phone ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Address", entity.Address ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@DateOfBirth", entity.DateOfBirth ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Gender", entity.Gender ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@HireDate", entity.HireDate ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@JobTitle", entity.JobTitle ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Salary", entity.Salary ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Department", entity.Department ?? (object)DBNull.Value);
        }

        protected override Employee Map(SqlDataReader reader)
        {
            return new Employee
            {
                EmployeeID = reader["EmployeeID"] as int?,
                FirstName = reader["FirstName"] as string,
                LastName = reader["LastName"] as string,
                Email = reader["Email"] as string,
                Phone = reader["Phone"] as string,
                Address = reader["Address"] as string,
                DateOfBirth = reader["DateOfBirth"] as DateTime?,
                Gender = reader["Gender"] as bool?,
                HireDate = reader["HireDate"] as DateTime?,
                JobTitle = reader["JobTitle"] as string,
                Salary = reader["Salary"] as decimal?,
                Department = reader["Department"] as string,
                CreatedAt = reader["CreatedAt"] as DateTime?,
                UpdatedAt = reader["UpdatedAt"] as DateTime?
            };
        }
    }
}
