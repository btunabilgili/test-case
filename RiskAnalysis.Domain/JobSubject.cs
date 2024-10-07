namespace RiskAnalysis.Domain
{
    public class JobSubject : BaseEntity<Guid>
    {
        public int JobID { get; set; }
        public int PartnerID { get; set; }

        public string SubjectDetails { get; set; }

        public Partner Partner { get; set; }
    }
}
