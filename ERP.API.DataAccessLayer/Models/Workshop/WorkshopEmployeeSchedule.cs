namespace ERP.API.DataAccessLayer.Models.Workshop
{
    public class WorkshopEmployeeSchedule : Analysis
    {
        public int? WorkshopEmployeeScheduleID { get; set; }
        public int? WorkshopID { get; set; }
        public int? EmployeeID { get; set; }
        public DateTime? ScheduledDate { get; set; }
        public TimeSpan? ScheduledStartTime { get; set; }
        public TimeSpan? ScheduledEndTime { get; set; }
        public TimeSpan? ActualStartTime { get; set; }
        public TimeSpan? ActualEndTime { get; set; }
        public WorkshopEmployeeSchedule() :base()
        {
            WorkshopEmployeeScheduleID = null;
            WorkshopID = null;
            EmployeeID = null;
            ScheduledDate = null;
            ScheduledStartTime = null;
            ScheduledEndTime = null;
            ActualStartTime = null;
            ActualEndTime = null;
        } 
    }
}
