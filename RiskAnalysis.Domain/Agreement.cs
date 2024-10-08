namespace RiskAnalysis.Domain
{
    public class Agreement : BaseEntity
    {
        public Guid PartnerId { get; set; }
        public DateTime AgreementDate { get; set; }
        public string AgreementDetails { get; set; } = string.Empty;
        public string Keywords { get; set; } = string.Empty;
        public decimal RiskLevel { get; set; }
        public string Status { get; set; } = string.Empty;

        public Partner Partner { get; set; } = null!;
    }
}
