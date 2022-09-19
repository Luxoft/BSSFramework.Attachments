using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AttachmentsSampleSystem.ServiceEnvironment;

public static class AttachmentsSampleSystemGeneralDependencyInjectionExtensions
{
    public static IServiceCollection RegisterGeneralDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        return services
               .RegisterGeneralBssFramework()
               .RegisterGeneralDatabaseSettings(configuration)
               .RegisterGeneralApplicationServices(configuration);
    }
}
