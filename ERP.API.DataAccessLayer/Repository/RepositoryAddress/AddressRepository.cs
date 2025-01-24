namespace ERP.API.DataAccessLayer.Repository.RepositoryAddress
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(string connectionString) : base(connectionString)
        {
        }

        protected override void AddParameters(SqlCommand command, Address entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            command.Parameters.AddWithValue("@AddressID", entity.AddressID ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@DistrictID", entity.DistrictID ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@StreetName", entity.StreetName ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BuildingNumber", entity.BuildingNumber ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@PropertyNumber", entity.PropertyNumber ?? (object)DBNull.Value);
            // Note: No parameters added for CreatedAt and UpdatedAt since they are inherited from Analysis.
        }

        protected override Address Map(SqlDataReader reader)
        {
            return new Address
            {
                AddressID = reader["AddressID"] as int?,
                DistrictID = reader["DistrictID"] as int?,
                StreetName = reader["StreetName"] as string,
                BuildingNumber = reader["BuildingNumber"] as string,
                PropertyNumber = reader["PropertyNumber"] as string,
                CreatedAt = reader["CreatedAt"] as DateTime?,  // Mapped from Analysis
                UpdatedAt = reader["UpdatedAt"] as DateTime?   // Mapped from Analysis
            };
        }
    }
}
