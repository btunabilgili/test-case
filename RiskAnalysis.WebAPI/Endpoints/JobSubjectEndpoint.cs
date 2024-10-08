using FluentValidation;
using RiskAnalysis.WebAPI.Models;

namespace RiskAnalysis.WebAPI.Endpoints
{
    public static class JobSubjectEndpoint
    {
        public static void RegisterJobSubjectEndpoint(this IEndpointRouteBuilder routes)
        {
            routes.MapPost("/api/v1/job-subject", (IValidator<JobSubjectModel> validator, JobSubjectModel model) =>
            {
                var validationResult = validator.Validate(model);

                if (!validationResult.IsValid)
                    return Results.ValidationProblem(validationResult.ToDictionary());

                return Results.Created();
            });
        }
    }
}
