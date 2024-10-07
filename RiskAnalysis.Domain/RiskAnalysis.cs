namespace RiskAnalysis.Domain
{
    public class RiskAnalysis : BaseEntity
    {
        public decimal RiskScore { get; set; }
        public DateTime AnalysisDate { get; set; }
        public string Comments { get; set; }

        public JobSubject JobSubject { get; set; }
    }

}
