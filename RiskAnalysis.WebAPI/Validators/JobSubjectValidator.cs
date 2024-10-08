using FluentValidation;
using RiskAnalysis.WebAPI.Models;

namespace RiskAnalysis.WebAPI.Validators
{
    public class JobSubjectValidator : AbstractValidator<JobSubjectModel>
    {
        public JobSubjectValidator()
        {
            RuleFor(x => x.AgreementId).NotEmpty();
            RuleFor(x => x.SubjectDetails).NotEmpty();
        }
    }
}
