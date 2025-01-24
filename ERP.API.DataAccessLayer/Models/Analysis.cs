namespace ERP.API.DataAccessLayer.Models
{
    public abstract class Analysis : AnalysisSharedProperty
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        protected Analysis() : base()
        {
            this.UpdatedAt = null;
            this.CreatedAt = null;
        }

    }
}
