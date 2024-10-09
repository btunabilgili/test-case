using AutoMapper;
using FluentValidation;
using RiskAnalysis.Application;
using RiskAnalysis.WebAPI.Extensions;
using RiskAnalysis.WebAPI.Models;

namespace RiskAnalysis.WebAPI.Endpoints
{
    public static class JobSubjectEndpoint
    {
        public static void RegisterJobSubjectEndpoint(this IEndpointRouteBuilder routes)
        {
            routes.MapPost("/api/v1/job-subject", async (
                IJobSubjectService service,
                IValidator<JobSubjectRequest> validator,
                IMapper mapper,
                HttpContext httpContext,
                JobSubjectRequest request,
                CancellationToken cancellationToken) =>
            {
                var validationResult = validator.Validate(request);

                if (!validationResult.IsValid)
                    return Results.ValidationProblem(validationResult.ToDictionary());

                var jobSubjectDto = mapper.Map<JobSubjectDto>(request);

                var result = await service.CreateJobSubjectAsync(jobSubjectDto, httpContext.User.GetPartnerId(), cancellationToken);

                if (result.IsError)
                    return Results.Problem(result.FirstError.Description);

                return Results.Ok(new { result.Value.RiskScore });
            });
        }
    }
}
