namespace ERP.API.DataAccessLayer.Repository.RepositoryAddress
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(string connectionString) : base(connectionString)
        {
        }

        protected override void AddParameters(SqlCommand command, Country entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            command.Parameters.AddWithValue("@CountryID", entity.CountryID ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CountryName", entity.CountryName ?? (object)DBNull.Value);
            // No parameters for CreatedAt and UpdatedAt (inherited from Analysis)
        }

        protected override Country Map(SqlDataReader reader)
        {
            return new Country
            {
                CountryID = reader["CountryID"] as int?,
                CountryName = reader["CountryName"] as string,
                CreatedAt = reader["CreatedAt"] as DateTime?,  // Mapped from Analysis
                UpdatedAt = reader["UpdatedAt"] as DateTime?   // Mapped from Analysis
            };
        }
    }
}
