namespace RiskAnalysis.Domain
{
    public class ServiceUser : BaseEntity
    {
        public Guid PartnerId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public Partner Partner { get; set; } = null!;
    }
}
