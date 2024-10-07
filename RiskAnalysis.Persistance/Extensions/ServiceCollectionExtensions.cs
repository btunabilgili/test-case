using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RiskAnalysis.Application;
using RiskAnalysis.Domain;
using RiskAnalysis.Persistance.Contexts;

namespace RiskAnalysis.Persistance.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("RiskAnalysis.Persistance"));
            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<ITestService, TestService>();

            return services;
        }
    }
}
