namespace RiskAnalysis.Application
{
    public class PartnerDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string PartnerName { get; set; } = string.Empty;
        public string ContactInfo { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public ServiceUserDto? ServiceUserDto { get; set; }
    }
}
