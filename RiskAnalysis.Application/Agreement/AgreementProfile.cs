using AutoMapper;
using RiskAnalysis.Domain;

namespace RiskAnalysis.Application
{
    public class AgreementProfile : Profile
    {
        public AgreementProfile()
        {
            CreateMap<Agreement, AgreementDto>()
                .ForMember(dest => dest.PartnerName, opt => opt.MapFrom(src => src.Partner.PartnerName));

            CreateMap<AgreementDto, Agreement>()
                .ForMember(dest => dest.Partner, opt => opt.Ignore());
        }
    }
}
