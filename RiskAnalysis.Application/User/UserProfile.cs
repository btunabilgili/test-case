using AutoMapper;
using RiskAnalysis.Domain;

namespace RiskAnalysis.Application
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom<CustomResolver>());

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Password, opt => opt.Ignore());
        }

        private class CustomResolver(IPasswordHashService hashService) : IValueResolver<UserDto, User, string>
        {
            public string Resolve(UserDto source, User destination, string destMember, ResolutionContext context)
            {
                return hashService.HashPassword(source.Password);
            }
        }
    }
}
