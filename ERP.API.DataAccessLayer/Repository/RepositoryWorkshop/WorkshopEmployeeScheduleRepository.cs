namespace ERP.API.DataAccessLayer.Repository.RepositoryWorkshop
{
    public class WorkshopEmployeeScheduleRepository : Repository<WorkshopEmployeeSchedule>, IWorkshopEmployeeScheduleRepository
    {
        public WorkshopEmployeeScheduleRepository(string connectionString) : base(connectionString)
        {
        }

        protected override void AddParameters(SqlCommand command, WorkshopEmployeeSchedule entity )
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            command.Parameters.AddWithValue("@WorkshopEmployeeScheduleID", entity.WorkshopEmployeeScheduleID ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@WorkshopID", entity.WorkshopID ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@EmployeeID", entity.EmployeeID ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ScheduledDate", entity.ScheduledDate ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ScheduledStartTime", entity.ScheduledStartTime ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ScheduledEndTime", entity.ScheduledEndTime ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ActualStartTime", entity.ActualStartTime ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ActualEndTime", entity.ActualEndTime ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CreatedAt", entity.CreatedAt ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@UpdatedAt", entity.UpdatedAt ?? (object)DBNull.Value);
        }

        protected override WorkshopEmployeeSchedule Map(SqlDataReader reader )
        {
            return new WorkshopEmployeeSchedule
            {
                WorkshopEmployeeScheduleID = reader["@WorkshopEmployeeScheduleID"] as int?,
                WorkshopID = reader["@WorkshopID"] as int?,
                EmployeeID = reader["@EmployeeID"] as int?,
                ScheduledDate = reader["@ScheduledDate"] as DateTime?,
                ScheduledStartTime = reader["@ScheduledStartTime"] as TimeSpan?,
                ScheduledEndTime = reader["@ScheduledEndTime"] as TimeSpan?,
                ActualStartTime = reader["@ActualStartTime"] as TimeSpan?,
                ActualEndTime = reader["@ActualEndTime"] as TimeSpan?,
                CreatedAt = reader["@CreatedAt"] as DateTime?,
                UpdatedAt = reader["@UpdatedAt"] as DateTime?
            };
        }
    }
}
