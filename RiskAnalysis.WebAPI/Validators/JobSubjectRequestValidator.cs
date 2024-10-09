using FluentValidation;
using RiskAnalysis.WebAPI.Models;

namespace RiskAnalysis.WebAPI.Validators
{
    public class JobSubjectRequestValidator : AbstractValidator<JobSubjectRequest>
    {
        public JobSubjectRequestValidator()
        {
            RuleFor(x => x.AgreementId).NotEmpty();
            RuleFor(x => x.JobSubjectDetails).NotEmpty();
        }
    }
}
