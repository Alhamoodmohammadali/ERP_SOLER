namespace ERP.API.DataAccessLayer.Repository.RepositoryAddress
{
    public class DistrictRepository : Repository<District>, IDistrictRepository
    {
        public DistrictRepository(string connectionString) : base(connectionString)
        {
        }
        protected override void AddParameters(SqlCommand command, District entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            command.Parameters.AddWithValue("@DistrictID", entity.DistrictID ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@DistrictName", entity.DistrictName ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CityID", entity.CityID ?? (object)DBNull.Value);
            // No parameters for CreatedAt and UpdatedAt (inherited from Analysis)
        }
        protected override District Map(SqlDataReader reader)
        {
            return new District
            {
                DistrictID = reader["DistrictID"] as int?,
                DistrictName = reader["DistrictName"] as string,
                CityID = reader["CityID"] as int?,
                CreatedAt = reader["CreatedAt"] as DateTime?,  // Mapped from Analysis
                UpdatedAt = reader["UpdatedAt"] as DateTime?   // Mapped from Analysis
            };
        }
    }
}
