namespace ERP.API.DataAccessLayer.Models.Workshop.DTOs.CreateDTOs
{
    public class CreateWorkshopEmployeeScheduleDTO

    {
        [Required(ErrorMessage = "WorkshopID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "WorkshopID must be a positive number.")]
        public int? WorkshopID { get; set; }

        [Required(ErrorMessage = "EmployeeID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "EmployeeID must be a positive number.")]
        public int? EmployeeID { get; set; }

        [Required(ErrorMessage = "ScheduledDate is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format for ScheduledDate.")]
        public DateTime? ScheduledDate { get; set; }

        [Required(ErrorMessage = "ScheduledStartTime is required.")]
        public TimeSpan? ScheduledStartTime { get; set; }

        [Required(ErrorMessage = "ScheduledEndTime is required.")]
        public TimeSpan? ScheduledEndTime { get; set; }

        public TimeSpan? ActualStartTime { get; set; }
        public TimeSpan? ActualEndTime { get; set; }
    }
}
