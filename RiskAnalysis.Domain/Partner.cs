namespace RiskAnalysis.Domain
{
    public class Partner : BaseEntity<Guid>
    {
        public string PartnerName { get; set; }
        public string ContactInfo { get; set; }
        public string Address { get; set; }

        public ICollection<Agreement> Agreements { get; set; }
        public ICollection<JobSubject> JobSubjects { get; set; }
    }
}
