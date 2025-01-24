namespace ERP.API.DataAccessLayer.Repository.RepositoryInvoice
{
    public class InvoicesRepository : Repository<Invoice>, IInvoicesRepository
    {
        public InvoicesRepository(string connectionString) : base(connectionString)
        {
        }
        protected override void AddParameters(SqlCommand command, Invoice entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            command.Parameters.AddWithValue("@InvoiceID", entity.InvoiceID ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CustomerID", entity.CustomerID ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@InvoiceDate", entity.InvoiceDate ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@TotalAmount", entity.TotalAmount ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@PaymentStatus", entity.PaymentStatus ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Description", entity.Description ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CreatedAt", entity.CreatedAt ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@UpdatedAt", entity.UpdatedAt ?? (object)DBNull.Value);
        }

        protected override Invoice Map(SqlDataReader reader)
        {
            return new Invoice
            {
                InvoiceID = reader["InvoiceID"] as int?,
                CustomerID = reader["CustomerID"] as int?,
                InvoiceDate = reader["InvoiceDate"] as DateTime?,
                TotalAmount = reader["TotalAmount"] as decimal?,
                PaymentStatus = reader["PaymentStatus"] as string,
                Description = reader["Description"] as string,
                CreatedAt = reader["CreatedAt"] as DateTime?,
                UpdatedAt = reader["UpdatedAt"] as DateTime?
            };
        }
    }
}
