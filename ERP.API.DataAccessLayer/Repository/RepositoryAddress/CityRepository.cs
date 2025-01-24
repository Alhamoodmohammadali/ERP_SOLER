namespace ERP.API.DataAccessLayer.Repository.RepositoryAddress
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(string connectionString) : base(connectionString)
        {
        }

        protected override void AddParameters(SqlCommand command, City entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            command.Parameters.AddWithValue("@CityID", entity.CityID ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CityName", entity.CityName ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CountryID", entity.CountryID ?? (object)DBNull.Value);
            // Note: No parameters added for CreatedAt and UpdatedAt since they are inherited from Analysis.
        }

        protected override City Map(SqlDataReader reader)
        {
            return new City
            {
                CityID = reader["CityID"] as int?,
                CityName = reader["CityName"] as string,
                CountryID = reader["CountryID"] as int?,
                CreatedAt = reader["CreatedAt"] as DateTime?, // Mapped from Analysis
                UpdatedAt = reader["UpdatedAt"] as DateTime?  // Mapped from Analysis
            };
        }
    }
}
