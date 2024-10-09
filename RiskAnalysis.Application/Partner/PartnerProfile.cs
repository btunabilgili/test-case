using AutoMapper;
using RiskAnalysis.Domain;

namespace RiskAnalysis.Application
{
    public class PartnerProfile : Profile
    {
        public PartnerProfile()
        {
            CreateMap<Partner, PartnerDto>()
                .ForMember(dest => dest.ServiceUserDto, opt =>
                    opt.MapFrom(src => src.ServiceUser))
                .ReverseMap()
                .ForMember(dest => dest.ServiceUser, opt =>
                    opt.MapFrom(src => src.ServiceUserDto));
        }
    }
}
