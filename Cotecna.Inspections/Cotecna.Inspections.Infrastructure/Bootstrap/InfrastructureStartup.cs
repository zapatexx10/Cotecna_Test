using Cotecna.Inspections.Abstractions.Bootstrap;
using Cotecna.Inspections.Abstractions.Repositories;
using Cotecna.Inspections.Infrastructure.Configuration;
using Cotecna.Inspections.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cotecna.Inspections.Infrastructure.Bootstrap
{
    public class InfrastructureStartup : IPartialStartup
    {
        public void RegisterConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration.GetSection("Database").Get<DatabaseConfiguration>());
        }

        public void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IInspectionsRepository, InspectionsRepository>();
        }
    }
}
