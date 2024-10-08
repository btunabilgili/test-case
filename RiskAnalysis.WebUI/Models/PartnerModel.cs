namespace RiskAnalysis.WebUI.Models
{
    public class PartnerModel
    {
        public Guid Id { get; set; }
        public string PartnerName { get; set; } = string.Empty;
        public string ContactInfo { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
