namespace RiskAnalysis.Domain
{
    public class Partner : BaseEntity
    {
        public string PartnerName { get; set; } = string.Empty;
        public string ContactInfo { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public ICollection<Agreement> Agreements { get; set; } = [];
        public ICollection<JobSubject> JobSubjects { get; set; } = [];
    }
}
