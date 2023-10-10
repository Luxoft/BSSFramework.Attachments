using System.Diagnostics.CodeAnalysis;

using AttachmentsSampleSystem.BLL;

using Framework.Authorization.BLL;
using Framework.Authorization.Notification;
using Framework.Cap;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AttachmentsSampleSystem.ServiceEnvironment;

public static class AttachmentsSampleSystemApplicationExtensions
{
    [SuppressMessage("SonarQube", "S4792", Justification = "reviewed")]
    public static IServiceCollection RegisterGeneralApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services
               .AddMediatR(opt => opt.RegisterServicesFromAssemblyContaining<EmployeeBLL>())
               .RegisterApplicationServices()
               .AddLogging()
               .AddCapBss(configuration.GetConnectionString("DefaultConnection"));
    }

    private static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<INotificationPrincipalExtractor, LegacyNotificationPrincipalExtractor>();

        return services;
    }
}
