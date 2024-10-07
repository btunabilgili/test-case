namespace RiskAnalysis.Domain
{
    public class RiskAnalysis : BaseEntity<Guid>
    {
        public int JobID { get; set; }

        public decimal RiskScore { get; set; }
        public DateTime AnalysisDate { get; set; }
        public string Comments { get; set; }

        public JobSubject JobSubject { get; set; }
    }

}
