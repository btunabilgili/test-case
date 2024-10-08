namespace RiskAnalysis.Domain
{
    public class JobSubject : BaseEntity
    {
        public Guid AgreementId { get; set; }
        public string SubjectDetails { get; set; } = string.Empty;
        public decimal? RiskScore { get; set; }

        public Agreement Agreement { get; set; } = null!;
    }
}
