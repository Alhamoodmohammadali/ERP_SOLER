namespace ERP.API.DataAccessLayer.Repository.RepositorySales
{
    public class SalesProductsRepository : Repository<SalesProduct>, ISalesProductsRepository
    {
        public SalesProductsRepository(string connectionString) : base(connectionString)
        {
        }

        protected override void AddParameters(SqlCommand command, SalesProduct entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            command.Parameters.AddWithValue("@SaleProductID", entity.SaleProductID ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@SaleID", entity.SaleID ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ProductID", entity.ProductID ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Quantity", entity.Quantity ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@UnitPrice", entity.UnitPrice ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CreatedAt", entity.CreatedAt ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@UpdatedAt", entity.UpdatedAt ?? (object)DBNull.Value);
        }

        protected override SalesProduct Map(SqlDataReader reader)
        {
            return new SalesProduct
            {
                SaleProductID = reader["SaleProductID"] as int?,
                SaleID = reader["SaleID"] as int?,
                ProductID = reader["ProductID"] as int?,
                Quantity = reader["Quantity"] as int?,
                UnitPrice = reader["UnitPrice"] as decimal?,
                CreatedAt = reader["CreatedAt"] as DateTime?,
                UpdatedAt = reader["UpdatedAt"] as DateTime?
            };
        }
    }
}
