namespace RiskAnalysis.WebAPI.Models
{
    public class JobSubjectRequest
    {
        public Guid AgreementId { get; set; }
        public string SubjectDetails { get; set; } = string.Empty;
    }
}
