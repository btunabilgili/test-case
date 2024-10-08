﻿using AutoMapper;
using ErrorOr;
using RiskAnalysis.Domain;

namespace RiskAnalysis.Application
{
    public interface IServiceAuthService : IApplicationService
    {
        Task<ErrorOr<ServiceUserDto>> ValidateUserAsync(ServiceUserDto userDto, CancellationToken cancellationToken = default);
        Task<ErrorOr<ServiceUserDto>> RegisterUserAsync(ServiceUserDto userDto, CancellationToken cancellationToken = default);
    }

    public class ServiceAuthService(IRepository<ServiceUser> repository, IMapper mapper) : IServiceAuthService
    {
        public async Task<ErrorOr<ServiceUserDto>> ValidateUserAsync(ServiceUserDto userDto, CancellationToken cancellationToken = default)
        {
            var mappedUser = mapper.Map<ServiceUser>(userDto);

            var user = await repository.GetFirstOrDefaultAsync(
                predicate: x =>
                    x.Username == mappedUser.Username &&
                    x.Password == mappedUser.Password,
                cancellationToken);

            if (user is null)
                return Error.Unauthorized(description: "Username or password is invalid");

            return mapper.Map<ServiceUserDto>(user);
        }

        public async Task<ErrorOr<ServiceUserDto>> RegisterUserAsync(ServiceUserDto userDto, CancellationToken cancellationToken = default)
        {
            if (await repository.GetFirstOrDefaultAsync(x => x.PartnerId == userDto.PartnerId, cancellationToken) is not null)
                return Error.Validation(description: "Partner already have account!");

            if (await repository.GetFirstOrDefaultAsync(x => x.Username == userDto.Username, cancellationToken) is not null)
                return Error.Validation(description: "Username already taken!");

            var user = mapper.Map<ServiceUser>(userDto);

            var createdUser = await repository.CreateAsync(user, cancellationToken);

            return mapper.Map<ServiceUserDto>(createdUser);
        }
    }
}
