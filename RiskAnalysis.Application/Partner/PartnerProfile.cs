using AutoMapper;
using RiskAnalysis.Domain;

namespace RiskAnalysis.Application
{
    public class PartnerProfile : Profile
    {
        public PartnerProfile()
        {
            CreateMap<Partner, PartnerDto>().ReverseMap();
        }
    }
}
