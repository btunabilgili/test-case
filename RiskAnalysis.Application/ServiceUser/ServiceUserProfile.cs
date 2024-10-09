using AutoMapper;
using RiskAnalysis.Domain;

namespace RiskAnalysis.Application
{
    public class ServiceUserProfile : Profile
    {
        public ServiceUserProfile()
        {
            CreateMap<ServiceUserDto, ServiceUser>().ReverseMap();
        }
    }
}
