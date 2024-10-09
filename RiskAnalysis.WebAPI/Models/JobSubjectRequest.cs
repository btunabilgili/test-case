namespace RiskAnalysis.WebAPI.Models
{
    public class JobSubjectRequest
    {
        public Guid AgreementId { get; set; }
        public string JobSubjectDetails { get; set; } = string.Empty;
    }
}
