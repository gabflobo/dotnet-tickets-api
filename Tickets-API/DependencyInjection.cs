using Tickets_API.Application;
using Tickets_API.Infrastructure;

namespace Tickets_API
{
    public static class DependencyInjection
    {
        public static IServiceCollection ApiDependencyInjections(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddApplicationDI()
                .AddInfrastructureDI(connectionString);
            

            return services;
        }
    }
}
