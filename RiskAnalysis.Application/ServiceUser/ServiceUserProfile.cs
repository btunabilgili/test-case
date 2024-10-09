using AutoMapper;
using RiskAnalysis.Domain;

namespace RiskAnalysis.Application
{
    public class ServiceUserProfile : Profile
    {
        public ServiceUserProfile()
        {
            CreateMap<ServiceUserDto, ServiceUser>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom<CustomResolver>());

            CreateMap<ServiceUser, ServiceUserDto>()
                .ForMember(dest => dest.Password, opt => opt.Ignore());
        }

        private class CustomResolver(IPasswordHashService hashService) : IValueResolver<ServiceUserDto, ServiceUser, string>
        {
            public string Resolve(ServiceUserDto source, ServiceUser destination, string destMember, ResolutionContext context)
            {
                return hashService.HashPassword(source.Password);
            }
        }
    }
}
