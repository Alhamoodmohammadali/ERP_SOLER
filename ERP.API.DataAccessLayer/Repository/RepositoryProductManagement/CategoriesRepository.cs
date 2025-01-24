namespace ERP.API.DataAccessLayer.Repository.RepositoryProductManagement
{
    public class CategoriesRepository : Repository<Category>, ICategoryRepository
    {
        public CategoriesRepository(string connectionString) : base(connectionString)
        {
        }

        protected override void AddParameters(SqlCommand command, Category entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (!(entity.CategoryID == null || entity.CategoryID <= 0))
            {
                command.Parameters.AddWithValue("@CategoryID", entity.CategoryID ?? (object)DBNull.Value);

            }
            command.Parameters.AddWithValue("@CategoryName", entity.CategoryName ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CategoryDescription", entity.CategoryDescription ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@IsActive", entity.IsActive ?? (object)DBNull.Value);
        }

        protected override Category Map(SqlDataReader reader)
        {
            return new Category
            {
                CategoryID = reader["CategoryID"] as int?,
                CategoryName = reader["CategoryName"] as string,
                CategoryDescription = reader["CategoryDescription"] as string,
                IsActive = reader["IsActive"] as bool?,
                CreatedAt = reader["CreatedAt"] as DateTime?,
                UpdatedAt = reader["UpdatedAt"] as DateTime?
            };
        }
    }
}
