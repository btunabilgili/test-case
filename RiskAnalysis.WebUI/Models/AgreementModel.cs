namespace RiskAnalysis.WebUI.Models
{
    public class AgreementModel
    {
        public Guid Id { get; set; }
        public Guid PartnerId { get; set; }
        public string PartnerName { get; set; } = string.Empty;
        public DateTime AgreementDate { get; set; }
        public string AgreementDetails { get; set; } = string.Empty;
        public string Keywords { get; set; } = string.Empty;
        public decimal RiskLevel { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
