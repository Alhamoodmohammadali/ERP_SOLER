namespace ERP.API.DataAccessLayer.Repository.RepositoryMaintenance
{
    public class MaintenanceOperationRepository : Repository<MaintenanceOperation>, IMaintenanceOperationRepository
    {
        public MaintenanceOperationRepository(string connectionString) : base(connectionString)
        {
        }
        protected override void AddParameters(SqlCommand command, MaintenanceOperation entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            command.Parameters.AddWithValue("@MaintenanceOperationID", entity.MaintenanceOperationID ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CustomerID", entity.CustomerID ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@EmployeeID", entity.EmployeeID ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ReceivedDate", entity.ReceivedDate ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ExpectedDeliveryDate", entity.ExpectedDeliveryDate ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ActualDeliveryDate", entity.ActualDeliveryDate ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ItemDescription", entity.ItemDescription ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@MaintenanceDetails", entity.MaintenanceDetails ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Status", entity.Status ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CreatedAt", entity.CreatedAt ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@UpdatedAt", entity.UpdatedAt ?? (object)DBNull.Value);
        }

        protected override MaintenanceOperation Map(SqlDataReader reader)
        {
            return new MaintenanceOperation
            {
                MaintenanceOperationID = reader["MaintenanceOperationID"] as int?,
                CustomerID = reader["CustomerID"] as int?,
                EmployeeID = reader["EmployeeID"] as int?,
                ReceivedDate = reader["ReceivedDate"] as DateTime?,
                ExpectedDeliveryDate = reader["ExpectedDeliveryDate"] as DateTime?,
                ActualDeliveryDate = reader["ActualDeliveryDate"] as DateTime?,
                ItemDescription = reader["ItemDescription"] as string,
                MaintenanceDetails = reader["MaintenanceDetails"] as string,
                Status = reader["Status"] as string,
                CreatedAt = reader["CreatedAt"] as DateTime?,
                UpdatedAt = reader["UpdatedAt"] as DateTime?
            };
        }
    }
}
