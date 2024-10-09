using RiskAnalysis.WebAPI.Endpoints;

namespace RiskAnalysis.WebAPI.Extensions
{
    public static class EndpointExtensions
    {
        public static void RegisterEndpoints(this IEndpointRouteBuilder app)
        {
            app.RegisterJobSubjectEndpoint();
            app.RegisterTokenEndpoint();
        }
    }
}
