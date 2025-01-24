namespace ERP.API.DataAccessLayer.Models.HRM.DTOs.CreateDTOs
{
    public class CreateEmployeeAttendanceDTO
    {
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
