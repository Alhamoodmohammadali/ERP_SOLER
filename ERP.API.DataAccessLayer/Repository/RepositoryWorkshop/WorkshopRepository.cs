namespace ERP.API.DataAccessLayer.Repository.RepositoryWorkshop
{
    public class WorkshopRepository : Repository<Workshop>, IWorkshopRepository
    {
        public WorkshopRepository(string connectionString) : base(connectionString)
        {
        }

        protected override void AddParameters(SqlCommand command, Workshop entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            command.Parameters.AddWithValue("@WorkshopID", entity.WorkshopID ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CustomerID", entity.CustomerID ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@WorkshopName", entity.WorkshopName ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Location", entity.Location ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Description", entity.Description ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@StartDate", entity.StartDate ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@EndDate", entity.EndDate ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CreatedAt", entity.CreatedAt ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@UpdatedAt", entity.UpdatedAt ?? (object)DBNull.Value);
        }

        protected override Workshop Map(SqlDataReader reader)
        {
            return new Workshop
            {
                WorkshopID = reader["@WorkshopID"] as int?,
                CustomerID = reader["@CustomerID"] as int?,
                WorkshopName = reader["@WorkshopName"].ToString(),
                Location = reader["@Location"].ToString(),
                Description = reader["@Description"].ToString(),
                StartDate = reader["@StartDate"] as DateTime?,
                EndDate = reader["@EndDate"] as DateTime?,
                CreatedAt = reader["@CreatedAt"] as DateTime?,
                UpdatedAt = reader["@UpdatedAt"] as DateTime?
            };
        }
    }
}
