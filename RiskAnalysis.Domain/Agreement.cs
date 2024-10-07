namespace RiskAnalysis.Domain
{
    public class Agreement : BaseEntity
    {
        public DateTime AgreementDate { get; set; }
        public string AgreementDetails { get; set; }
        public decimal RiskLevel { get; set; }
        public string Status { get; set; }

        public Partner Partner { get; set; }
    }

}
