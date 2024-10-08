namespace RiskAnalysis.Domain
{
    public class JobSubject : BaseEntity
    {
        public Guid PartnerId { get; set; }
        public string SubjectDetails { get; set; } = string.Empty;
        public decimal? RiskScore { get; set; }

        public Partner Partner { get; set; } = null!;
    }
}
