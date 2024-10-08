using AutoMapper;
using ErrorOr;
using RiskAnalysis.Common;
using RiskAnalysis.Domain;

namespace RiskAnalysis.Application
{
    public interface IAgreementService : IApplicationService
    {
        Task<ErrorOr<Created>> CreateAgreementAsync(AgreementDto dto, CancellationToken cancellationToken = default);
        Task<ErrorOr<Deleted>> DeleteAgreementAsync(Guid id, CancellationToken cancellationToken = default);
        Task<ErrorOr<AgreementDto>> GetAgreementByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<ErrorOr<List<AgreementDto>>> GetAgreementsAsync(CancellationToken cancellationToken = default);
        Task<ErrorOr<Updated>> UpdateAgreementAsync(Guid id, AgreementDto dto, CancellationToken cancellationToken = default);
    }

    public class AgreementService(IRepository<Agreement> repository, IMapper mapper) : IAgreementService
    {
        public async Task<ErrorOr<List<AgreementDto>>> GetAgreementsAsync(CancellationToken cancellationToken = default)
        {
            var agreements = await repository.GetAllAsync(include: x => x.Partner, cancellationToken);

            return mapper.Map<List<AgreementDto>>(agreements);
        }

        public async Task<ErrorOr<AgreementDto>> GetAgreementByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var agreement = await repository.GetByIdAsync(id, cancellationToken);

            if (agreement is null)
                return Error.NotFound(description: Constants.RecordNotFound);

            return mapper.Map<AgreementDto>(agreement);
        }

        public async Task<ErrorOr<Created>> CreateAgreementAsync(AgreementDto dto, CancellationToken cancellationToken = default)
        {
            var agreement = mapper.Map<Agreement>(dto);

            await repository.CreateAsync(agreement, cancellationToken);

            return Result.Created;
        }

        public async Task<ErrorOr<Updated>> UpdateAgreementAsync(Guid id, AgreementDto dto, CancellationToken cancellationToken = default)
        {
            var existingAgreement = await repository.GetByIdAsync(id, cancellationToken);

            if (existingAgreement is null)
                return Error.NotFound(description: Constants.RecordNotFound);

            mapper.Map(dto, existingAgreement);

            await repository.UpdateAsync(existingAgreement, cancellationToken);

            return Result.Updated;
        }

        public async Task<ErrorOr<Deleted>> DeleteAgreementAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var agreement = await repository.GetByIdAsync(id, cancellationToken);

            if (agreement is null)
                return Error.NotFound(description: Constants.RecordNotFound);

            await repository.DeleteAsync(agreement, cancellationToken);

            return Result.Deleted;
        }
    }
}
