using System.Security.Claims;

namespace RiskAnalysis.WebAPI.Extensions
{
    public static class ClaimsExtensions
    {
        public static Guid GetPartnerId(this ClaimsPrincipal user)
        {
            ArgumentNullException.ThrowIfNull(user);

            var partnerId = user.FindFirst("PartnerId")?.Value;

            ArgumentException.ThrowIfNullOrEmpty(partnerId);

            return Guid.Parse(partnerId);
        }
    }
}
