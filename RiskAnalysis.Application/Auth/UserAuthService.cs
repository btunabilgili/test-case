using AutoMapper;
using ErrorOr;
using RiskAnalysis.Domain;

namespace RiskAnalysis.Application
{
    public interface IUserAuthService : IApplicationService
    {
        Task<ErrorOr<UserDto>> ValidateUserAsync(UserDto userDto, CancellationToken cancellationToken = default);
        Task<ErrorOr<UserDto>> RegisterUserAsync(UserDto userDto);
    }

    public class UserAuthService(IRepository<User> repository, IMapper mapper) : IUserAuthService
    {
        public async Task<ErrorOr<UserDto>> ValidateUserAsync(UserDto userDto, CancellationToken cancellationToken = default)
        {
            var mappedUser = mapper.Map<User>(userDto);

            var user = await repository.GetFirstOrDefaultAsync(
                predicate: x =>
                    x.Username == mappedUser.Username &&
                    x.Password == mappedUser.Password,
                cancellationToken);

            if (user is null)
                return Error.Unauthorized(description: "Username or password is invalid");

            return mapper.Map<UserDto>(user);
        }

        public async Task<ErrorOr<UserDto>> RegisterUserAsync(UserDto userDto)
        {
            var user = mapper.Map<User>(userDto);

            var createdUser = await repository.CreateAsync(user);

            return mapper.Map<UserDto>(createdUser);
        }
    }
}
