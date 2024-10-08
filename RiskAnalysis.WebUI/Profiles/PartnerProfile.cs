using AutoMapper;
using RiskAnalysis.Application;
using RiskAnalysis.WebUI.Models;

namespace RiskAnalysis.WebUI.Profiles
{
    public class PartnerProfile : Profile
    {
        public PartnerProfile()
        {
            CreateMap<PartnerDto, PartnerModel>().ReverseMap();

            CreateMap<PartnerCreateModel, PartnerDto>().ReverseMap();
        }
    }
}
