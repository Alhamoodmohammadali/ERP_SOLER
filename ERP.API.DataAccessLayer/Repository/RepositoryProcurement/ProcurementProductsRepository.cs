namespace ERP.API.DataAccessLayer.Repository.RepositoryProcurement
{
    public class ProcurementProductsRepository : Repository<ProcurementProduct>, IProcurementProductsRepository
    {
        public ProcurementProductsRepository(string connectionString) : base(connectionString)
        {
        }
        protected override void AddParameters(SqlCommand command, ProcurementProduct entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            command.Parameters.AddWithValue("@ProcurementProductID", entity.ProcurementProductID ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ProcurementID", entity.ProcurementID ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ProductID", entity.ProductID ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Quantity", entity.Quantity ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@UnitPrice", entity.UnitPrice ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CreatedAt", entity.CreatedAt ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@UpdatedAt", entity.UpdatedAt ?? (object)DBNull.Value);
        }

        protected override ProcurementProduct Map(SqlDataReader reader)
        {
            return new ProcurementProduct
            {
                ProcurementProductID = reader["ProcurementProductID"] as int?,
                ProcurementID = reader["ProcurementID"] as int?,
                ProductID = reader["ProductID"] as int?,
                Quantity = reader["Quantity"] as int?,
                UnitPrice = reader["UnitPrice"] as decimal?,
                CreatedAt = reader["CreatedAt"] as DateTime?,
                UpdatedAt = reader["UpdatedAt"] as DateTime?
            };
        }
    }
}
