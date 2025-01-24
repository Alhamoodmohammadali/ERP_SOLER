namespace ERP.API.DataAccessLayer.Models.Workshop
{
    public class Workshop : Analysis
    {
        public int? WorkshopID { get; set; }
        public int? CustomerID { get; set; }
        public string? WorkshopName { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Workshop() : base()
        {
            WorkshopID = null;
            CustomerID = null;
            WorkshopName = null;
            Location = null;
            Description = null;
            StartDate = null;
            EndDate = null;
        }
    }
}
