namespace ERP.API.DataAccessLayer.Models
{
    public class AnalysisSharedProperty
    {
        public string? TenantID { get; set; }
        public string? UserId { get; set; }

        public AnalysisSharedProperty()
        {
            this.TenantID = null;
            this.UserId = null;
        }
    }
}
