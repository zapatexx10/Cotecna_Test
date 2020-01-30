using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cotecna.Inspections.Abstractions.Bootstrap
{
    public interface IPartialStartup
    {
        void RegisterConfiguration(IServiceCollection services, IConfiguration configuration);
        void RegisterServices(IServiceCollection services);
    }
}
