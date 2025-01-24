namespace ERP.API.DataAccessLayer.Repository.RepositoryProcurement
{
    public class ProcurementsRepository : Repository<Procurement>, IProcurementsRepository
    {
        public ProcurementsRepository(string connectionString) : base(connectionString)
        {
        }

        protected override void AddParameters(SqlCommand command, Procurement entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            command.Parameters.AddWithValue("@ProcurementID", entity.ProcurementID ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@SupplierID", entity.SupplierID ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@PurchaseDate", entity.PurchaseDate ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@TotalAmount", entity.TotalAmount ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@PaymentMethod", entity.PaymentMethod ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ProcurementStatus", entity.ProcurementStatus ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CreatedAt", entity.CreatedAt ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@UpdatedAt", entity.UpdatedAt ?? (object)DBNull.Value);
        }

        protected override Procurement Map(SqlDataReader reader)
        {
            return new Procurement
            {
                ProcurementID = reader["ProcurementID"] as int?,
                SupplierID = reader["SupplierID"] as int?,
                PurchaseDate = reader["PurchaseDate"] as DateTime?,
                TotalAmount = reader["TotalAmount"] as decimal?,
                PaymentMethod = reader["PaymentMethod"].ToString(),
                ProcurementStatus = reader["ProcurementStatus"].ToString(),
                CreatedAt = reader["CreatedAt"] as DateTime?,
                UpdatedAt = reader["UpdatedAt"] as DateTime?
            };
        }
    }
}
