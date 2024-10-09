using ErrorOr;
using RiskAnalysis.Domain;

namespace RiskAnalysis.Application
{
    public interface IJobSubjectService : IApplicationService
    {
        Task<ErrorOr<JobSubject>> CreateJobSubjectAsync(
            JobSubjectDto jobSubjectDto,
            Guid partnerId,
            CancellationToken cancellationToken = default);
    }

    public class JobSubjectService(IRepository<Agreement> agreementRepository, IRepository<JobSubject> jobSubjectRepository) : IJobSubjectService
    {
        public async Task<ErrorOr<JobSubject>> CreateJobSubjectAsync(
            JobSubjectDto jobSubjectDto,
            Guid partnerId,
            CancellationToken cancellationToken = default)
        {
            var agreement = await agreementRepository.GetFirstOrDefaultAsync(
                predicate: x =>
                    x.Id == jobSubjectDto.AgreementId &&
                    x.PartnerId == partnerId,
                cancellationToken);

            if (agreement is null)
                return Error.Forbidden();

            var riskScore = CalculateRiskScore(jobSubjectDto.JobSubjectDetails, agreement.Keywords, agreement.RiskLevel);

            var jobSubject = await jobSubjectRepository.CreateAsync(new JobSubject
            {
                AgreementId = agreement.Id,
                SubjectDetails = jobSubjectDto.JobSubjectDetails,
                RiskScore = riskScore
            }, cancellationToken);

            return jobSubject;
        }

        private static decimal CalculateRiskScore(string subjectDetail, string keywords, decimal riskLevel)
        {
            var keywordsList = keywords.Split(',');
            int keywordCounter = 0;

            foreach (var keyword in keywordsList)
            {
                if (subjectDetail.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                    keywordCounter++;
            }

            return keywordCounter * riskLevel;
        }
    }
}
