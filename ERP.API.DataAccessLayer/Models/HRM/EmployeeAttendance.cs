namespace ERP.API.DataAccessLayer.Models.HRM
{
    public class EmployeeAttendance :Analysis
    {
        public int? EmployeeAttendanceID { get; set; }
        public int? EmployeeID { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public EmployeeAttendance()
        {
            EmployeeAttendanceID = null;
            EmployeeID = null;
            CheckInTime = null;
            CheckOutTime = null;
        }
    }
}
