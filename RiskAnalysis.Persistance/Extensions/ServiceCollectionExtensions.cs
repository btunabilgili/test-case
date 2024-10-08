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

            RegisterApplicationServices(services);

            return services;
        }


        private static void RegisterApplicationServices(IServiceCollection services)
        {
            var serviceType = typeof(IApplicationService);
            var assembly = serviceType.Assembly;

            var types = assembly.GetTypes()
                .Where(t => serviceType.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);

            foreach (var type in types)
            {
                var interfaceType = type.GetInterfaces().FirstOrDefault(i => serviceType.IsAssignableFrom(i));
                if (interfaceType != null)
                {
                    services.AddTransient(interfaceType, type);
                }
            }
        }
    }
}
