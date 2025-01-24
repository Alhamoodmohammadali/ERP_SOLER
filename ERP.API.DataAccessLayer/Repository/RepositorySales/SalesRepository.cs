namespace ERP.API.DataAccessLayer.Repository.RepositorySales
{
    public class SalesRepository : Repository<Sale>, ISalesRepository
    {
        public SalesRepository(string connectionString) : base(connectionString)
        {
        }

        protected override void AddParameters(SqlCommand command, Sale entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            command.Parameters.AddWithValue("@SaleID", entity.SaleID ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CustomerID", entity.CustomerID ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@SaleDate", entity.SaleDate ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@TotalAmount", entity.TotalAmount ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@PaymentMethod", entity.PaymentMethod ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@SaleStatus", entity.SaleStatus ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CreatedAt", entity.CreatedAt ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@UpdatedAt", entity.UpdatedAt ?? (object)DBNull.Value);
        }

        protected override Sale Map(SqlDataReader reader)
        {
            return new Sale
            {
                SaleID = reader["@SaleID"] as int?,
                CustomerID = reader["@CustomerID"] as int?,
                SaleDate = reader["@SaleDate"] as DateTime?,
                TotalAmount = reader["@TotalAmount"] as decimal?,
                PaymentMethod = reader["@PaymentMethod"].ToString(),
                SaleStatus = reader["@SaleStatus"].ToString(),
                CreatedAt = reader["@CreatedAt"] as DateTime?,
                UpdatedAt = reader["@UpdatedAt"] as DateTime?
            };
        }
    }
}
