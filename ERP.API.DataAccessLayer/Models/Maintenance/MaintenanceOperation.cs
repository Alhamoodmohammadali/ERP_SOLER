namespace ERP.API.DataAccessLayer.Models.Maintenance
{
    public class MaintenanceOperation : Analysis
    {
        public int? MaintenanceOperationID { get; set; }
        public int? CustomerID { get; set; }
        public int? EmployeeID { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public DateTime? ActualDeliveryDate { get; set; }
        public string? ItemDescription { get; set; }
        public string? MaintenanceDetails { get; set; }
        public string? Status { get; set; }
        public MaintenanceOperation() : base()
        {
            MaintenanceOperationID = 0;
            CustomerID = null;
            EmployeeID = null;
            ReceivedDate = null;
            ExpectedDeliveryDate = null;
            ActualDeliveryDate = null;
            ItemDescription = null;
            MaintenanceDetails = null;
            Status = null;
        }
    }
}
