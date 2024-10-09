using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RiskAnalysis.Application;
using RiskAnalysis.Common;
using RiskAnalysis.WebAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RiskAnalysis.WebAPI.Endpoints
{
    public static class TokenEndpoint
    {
        public static void RegisterTokenEndpoint(this IEndpointRouteBuilder routes)
        {
            routes.MapPost("/api/token", async (
                [FromServices] IConfiguration configuration,
                [FromServices] IValidator<TokenRequest> validator,
                [FromServices] IServiceAuthService service,
                [FromServices] IMapper mapper,
                [FromBody] TokenRequest request,
                CancellationToken cancellationToken) =>
            {
                var validationResult = validator.Validate(request);

                if (!validationResult.IsValid)
                    return Results.ValidationProblem(validationResult.ToDictionary());

                var serviceUserDto = mapper.Map<ServiceUserDto>(request);

                var result = await service.ValidateUserAsync(serviceUserDto, cancellationToken);

                if (result.IsError)
                    return Results.Problem(result.FirstError.Description);

                var (token, expireDate) = GenerateJwtToken(configuration, result.Value.PartnerId);

                return Results.Ok(new { token, expireDate });
            }).AllowAnonymous();
        }

        private static (string, DateTime) GenerateJwtToken(IConfiguration configuration, Guid partnerId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(configuration["Jwt:JwtIssuerSigningKey"]!);

            var expireDate = DateTime.UtcNow.AddHours(1);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(Constants.PartnerIdClaim, partnerId.ToString())
                }),
                Expires = expireDate,
                Issuer = configuration["Jwt:Issuer"],
                Audience = configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return (tokenHandler.WriteToken(token), expireDate);
        }
    }
}
