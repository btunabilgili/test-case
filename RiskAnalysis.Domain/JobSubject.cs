namespace RiskAnalysis.Domain
{
    public class JobSubject : BaseEntity
    {
        public string SubjectDetails { get; set; }

        public Partner Partner { get; set; }
    }
}
