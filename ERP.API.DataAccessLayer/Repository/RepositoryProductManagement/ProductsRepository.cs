namespace ERP.API.DataAccessLayer.Repository.RepositoryProductManagement
{
    public class ProductsRepository : Repository<Product>, IProductsRepository
    {
        public ProductsRepository(string connectionString) : base(connectionString)
        {
        }

        protected override void AddParameters(SqlCommand command, Product entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            command.Parameters.AddWithValue("@ProductID", entity.ProductID ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ProductName", entity.ProductName ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ProductDescription", entity.ProductDescription ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CategoryID", entity.CategoryID ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Price", entity.Price ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@QuantityAvailable", entity.QuantityAvailable ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@SKU", entity.SKU ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@IsActive", entity.IsActive ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CreatedAt", entity.CreatedAt ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@UpdatedAt", entity.UpdatedAt ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@QuantityInStock", entity.QuantityInStock ?? (object)DBNull.Value);
        }

        protected override Product Map(SqlDataReader reader)
        {
            return new Product
            {
                ProductID = reader["ProductID"] as int?,
                ProductName = reader["ProductName"].ToString(),
                ProductDescription = reader["ProductDescription"].ToString(),
                CategoryID = reader["CategoryID"] as int?,
                Price = reader["Price"] as decimal?,
                QuantityAvailable = reader["QuantityAvailable"] as int?,
                SKU = reader["SKU"].ToString(),
                IsActive = reader["IsActive"] as bool?,
                CreatedAt = reader["CreatedAt"] as DateTime?,
                UpdatedAt = reader["UpdatedAt"] as DateTime?,
                QuantityInStock = reader["QuantityInStock"] as int?
            };
        }
    }
}
