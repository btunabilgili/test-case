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
            CreateMap<AgreementDto, AgreementCreateModel>().ReverseMap();
        }
    }
}
