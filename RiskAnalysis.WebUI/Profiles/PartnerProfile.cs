using AutoMapper;
using RiskAnalysis.Application;
using RiskAnalysis.WebUI.Models;

namespace RiskAnalysis.WebUI.Profiles
{
    public class PartnerProfile : Profile
    {
        public PartnerProfile()
        {
            CreateMap<PartnerDto, PartnerModel>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.ServiceUserDto))
                .ReverseMap()
                .ForMember(dest => dest.ServiceUserDto, opt => opt.MapFrom(src => src.User));

            CreateMap<PartnerUserModel, ServiceUserDto>()
                .ForMember(dest => dest.Password, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<PartnerUserCreateModel, ServiceUserDto>().ReverseMap();
        }
    }
}
