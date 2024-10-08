using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace RiskAnalysis.WebUI.Models
{
    public class AgreementCreateModel
    {
        public Guid Id { get; set; }
        [Required]
        public Guid? PartnerId { get; set; }
        public List<SelectListItem> Partners { get; set; } = [];
        [Required]
        public DateTime AgreementDate { get; set; } = DateTime.UtcNow;
        [Required]
        public string AgreementDetails { get; set; } = string.Empty;
        [Required]
        public List<string> Keywords { get; set; } = [];
        [Required]
        public decimal? RiskLevel { get; set; }
        [Required]
        public string? Status { get; set; }
        public List<SelectListItem> Statuses { get; set; } = [];
    }
}
