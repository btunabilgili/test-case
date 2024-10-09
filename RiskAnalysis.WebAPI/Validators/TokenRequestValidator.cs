using FluentValidation;
using RiskAnalysis.WebAPI.Models;

namespace RiskAnalysis.WebAPI.Validators
{
    public class TokenRequestValidator : AbstractValidator<TokenRequest>
    {
        public TokenRequestValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
