using AutoMapper;
using RiskAnalysis.Application;
using RiskAnalysis.WebUI.Models;

namespace RiskAnalysis.WebUI.Profiles
{
    public class AgreementProfile : Profile
    {
        public AgreementProfile()
        {
            CreateMap<AgreementDto, AgreementModel>().ReverseMap();

            CreateMap<AgreementDto, AgreementCreateModel>()
                .ForMember(dest => dest.Keywords, opt => opt.MapFrom(x => string.IsNullOrEmpty(x.Keywords) ? Array.Empty<string>() : x.Keywords.Split(",", StringSplitOptions.None)));

            CreateMap<AgreementCreateModel, AgreementDto>()
                .ForMember(dest => dest.Keywords, opt => opt.MapFrom(x => x.Keywords == null || !x.Keywords.Any() ? string.Empty : string.Join(",", x.Keywords)));
        }
    }
}
