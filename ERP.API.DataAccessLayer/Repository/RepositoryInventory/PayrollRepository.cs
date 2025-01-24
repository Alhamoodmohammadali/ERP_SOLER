namespace ERP.API.DataAccessLayer.Repository.RepositoryInventory
{
    public class PayrollRepository : Repository<Payroll>, IPayrollRepository
    {
        public PayrollRepository(string connectionString) : base(connectionString)
        {
        }

        protected override void AddParameters(SqlCommand command, Payroll entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            command.Parameters.AddWithValue("@PayrollID", entity.PayrollID ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@EmployeeID", entity.EmployeeID ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@PayPeriodStart", entity.PayPeriodStart ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@PayPeriodEnd", entity.PayPeriodEnd ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@TotalHoursWorked", entity.TotalHoursWorked ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@RegularHours", entity.RegularHours ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@OvertimeHours", entity.OvertimeHours ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@DoubleOvertimeHours", entity.DoubleOvertimeHours ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@RegularPay", entity.RegularPay ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@OvertimePay", entity.OvertimePay ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@DoubleOvertimePay", entity.DoubleOvertimePay ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@TotalPay", entity.TotalPay ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CreatedAt", entity.CreatedAt ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@UpdatedAt", entity.UpdatedAt ?? (object)DBNull.Value);
        }

        protected override Payroll Map(SqlDataReader reader)
        {
            return new Payroll
            {
                PayrollID = reader["PayrollID"] as int?,
                EmployeeID = reader["EmployeeID"] as int?,
                PayPeriodStart = reader["PayPeriodStart"] as DateTime?,
                PayPeriodEnd = reader["PayPeriodEnd"] as DateTime?,
                TotalHoursWorked = reader["TotalHoursWorked"] as decimal?,
                RegularHours = reader["RegularHours"] as decimal?,
                OvertimeHours = reader["OvertimeHours"] as decimal?,
                DoubleOvertimeHours = reader["DoubleOvertimeHours"] as decimal?,
                RegularPay = reader["RegularPay"] as decimal?,
                OvertimePay = reader["OvertimePay"] as decimal?,
                DoubleOvertimePay = reader["DoubleOvertimePay"] as decimal?,
                TotalPay = reader["TotalPay"] as decimal?,
                CreatedAt = reader["CreatedAt"] as DateTime?,
                UpdatedAt = reader["UpdatedAt"] as DateTime?
            };
        }
    }
}
