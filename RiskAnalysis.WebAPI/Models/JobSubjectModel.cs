namespace RiskAnalysis.WebAPI.Models
{
    public class JobSubjectModel
    {
        public Guid AgreementId { get; set; }
        public string SubjectDetails { get; set; } = string.Empty;
    }
}
