namespace ERP.API.DataAccessLayer.Models.HRM.DTOs.UpdateDTOs
{
    public class UpdateEmployeeAttendanceDTO
    {
        [Required(ErrorMessage = "AttendanceID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "AttendanceID must be a positive number.")]
        public int? AttendanceID { get; set; }

        [Required(ErrorMessage = "EmployeeID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "EmployeeID must be a positive number.")]
        public int? EmployeeID { get; set; }

        [Required(ErrorMessage = "CheckInTime is required.")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid date and time format for CheckInTime.")]
        public DateTime? CheckInTime { get; set; }

        [Required(ErrorMessage = "CheckOutTime is required.")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid date and time format for CheckOutTime.")]
        public DateTime? CheckOutTime { get; set; }
    }
}
