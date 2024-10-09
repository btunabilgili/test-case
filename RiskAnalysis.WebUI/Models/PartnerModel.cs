namespace RiskAnalysis.WebUI.Models
{
    public class PartnerModel
    {
        public Guid Id { get; set; }
        public string PartnerName { get; set; } = string.Empty;
        public string ContactInfo { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public PartnerUserModel? User { get; set; }
    }

    public class PartnerUserModel
    {
        public Guid Id { get; set; }
        public Guid PartnerId { get; set; }
        public string Username { get; set; } = string.Empty;
    }
}
