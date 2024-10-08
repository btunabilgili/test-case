using AutoMapper;
using RiskAnalysis.Application.Auth;
using RiskAnalysis.WebUI.Models;

namespace RiskAnalysis.WebUI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<LoginModel, UserDto>();
            CreateMap<RegisterModel, UserDto>();
        }
    }
}
