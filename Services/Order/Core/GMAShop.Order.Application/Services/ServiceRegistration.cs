using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GMAShop.Order.Application.Services;

public static class ServiceRegistration
{
    public static void AddApplicationService(this IServiceCollection services, ConfigurationManager builderConfiguration)
    {
        services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));
    }
}