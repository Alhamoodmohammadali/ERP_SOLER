namespace ERP.API.DataAccessLayer.Repository.RepositoryHRM
{
    public class EmployeeAttendanceRepository : Repository<EmployeeAttendance>, IEmployeeAttendanceRepository
    {
        public EmployeeAttendanceRepository(string connectionString) : base(connectionString)
        {
        }

        protected override void AddParameters(SqlCommand command, EmployeeAttendance entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            command.Parameters.AddWithValue("@EmployeeAttendanceID", entity.EmployeeAttendanceID ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@EmployeeID", entity.EmployeeID ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CheckInTime", entity.CheckInTime ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CheckOutTime", entity.CheckOutTime ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CreatedAt", entity.CreatedAt ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@UpdatedAt", entity.UpdatedAt ?? (object)DBNull.Value);
        }

        protected override EmployeeAttendance Map(SqlDataReader reader)
        {
            return new EmployeeAttendance
            {
                EmployeeAttendanceID = reader["EmployeeAttendanceID"] as int?,
                EmployeeID = reader["EmployeeID"] as int?,
                CheckInTime = reader["CheckInTime"] as DateTime?,
                CheckOutTime = reader["CheckOutTime"] as DateTime?,
                CreatedAt = reader["CreatedAt"] as DateTime?,
                UpdatedAt = reader["UpdatedAt"] as DateTime?
            };
        }
    }
}
