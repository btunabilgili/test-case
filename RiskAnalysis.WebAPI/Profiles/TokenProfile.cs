using AutoMapper;
using RiskAnalysis.Application;
using RiskAnalysis.WebAPI.Models;

namespace RiskAnalysis.WebAPI.Profiles
{
    public class TokenProfile : Profile
    {
        public TokenProfile()
        {
            CreateMap<TokenRequest, ServiceUserDto>();
        }
    }
}
