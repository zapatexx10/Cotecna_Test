using Cotecna.Inspections.Abstractions.Bootstrap;
using Cotecna.Inspections.Abstractions.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cotecna.Inspections.Core.Bootstrap
{
    public class CoreStartup: IPartialStartup
    {
        public void RegisterConfiguration(IServiceCollection services, IConfiguration configuration)
        {

        }

        public void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IInspectionService, InspectionService>();
        }
    }
}
