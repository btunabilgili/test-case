namespace RiskAnalysis.Domain
{
    public class JobSubject : BaseEntity<Guid>
    {
        public string SubjectDetails { get; set; }

        public Partner Partner { get; set; }
    }
}
