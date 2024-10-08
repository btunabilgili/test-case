using System.ComponentModel.DataAnnotations;

namespace RiskAnalysis.Domain
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
