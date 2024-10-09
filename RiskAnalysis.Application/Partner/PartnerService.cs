using AutoMapper;
using ErrorOr;
using RiskAnalysis.Common;
using RiskAnalysis.Domain;

namespace RiskAnalysis.Application
{
    public interface IPartnerService : IApplicationService
    {
        Task<ErrorOr<List<PartnerDto>>> GetPartnersAsync(CancellationToken cancellationToken = default);
        Task<ErrorOr<PartnerDto>> GetPartnerByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<ErrorOr<Created>> CreatePartnerAsync(PartnerDto dto, CancellationToken cancellationToken = default);
        Task<ErrorOr<Updated>> UpdatePartnerAsync(Guid id, PartnerDto dto, CancellationToken cancellationToken = default);
        Task<ErrorOr<Deleted>> DeletePartnerAsync(Guid id, CancellationToken cancellationToken = default);
    }

    public class PartnerService(IRepository<Partner> repository, IMapper mapper) : IPartnerService
    {
        public async Task<ErrorOr<List<PartnerDto>>> GetPartnersAsync(CancellationToken cancellationToken = default)
        {
            var partners = await repository.GetAllAsync(include: x => x.ServiceUser, cancellationToken: cancellationToken);

            return mapper.Map<List<PartnerDto>>(partners);
        }

        public async Task<ErrorOr<PartnerDto>> GetPartnerByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var partner = await repository.GetByIdAsync(id, cancellationToken);

            if (partner is null)
                return Error.NotFound(description: Constants.RecordNotFound);

            return mapper.Map<PartnerDto>(partner);
        }

        public async Task<ErrorOr<Created>> CreatePartnerAsync(PartnerDto dto, CancellationToken cancellationToken = default)
        {
            if (await repository.GetFirstOrDefaultAsync(x => x.PartnerName == dto.PartnerName, cancellationToken) is not null)
                return Error.Validation(description: "PartnerName already exits!");

            var partner = mapper.Map<Partner>(dto);

            await repository.CreateAsync(partner, cancellationToken);

            return Result.Created;
        }

        public async Task<ErrorOr<Updated>> UpdatePartnerAsync(Guid id, PartnerDto dto, CancellationToken cancellationToken = default)
        {
            if (await repository.GetFirstOrDefaultAsync(x => x.Id != id && x.PartnerName == dto.PartnerName, cancellationToken) is not null)
                return Error.Validation(description: "PartnerName already exits!");

            var existingPartner = await repository.GetByIdAsync(id, cancellationToken);

            if (existingPartner is null)
                return Error.NotFound(description: Constants.RecordNotFound);

            mapper.Map(dto, existingPartner);

            await repository.UpdateAsync(existingPartner, cancellationToken);

            return Result.Updated;
        }

        public async Task<ErrorOr<Deleted>> DeletePartnerAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var partner = await repository.GetByIdAsync(id, cancellationToken);

            if (partner is null)
                return Error.NotFound(description: Constants.RecordNotFound);

            await repository.DeleteAsync(partner, cancellationToken);

            return Result.Deleted;
        }
    }
}
