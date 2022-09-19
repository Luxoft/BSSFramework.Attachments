using System.Reflection;

using Framework.Authorization.BLL;
using Framework.Cap;
using Framework.DependencyInjection;

using MediatR;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using AttachmentsSampleSystem.BLL;

namespace AttachmentsSampleSystem.ServiceEnvironment;

public static class AttachmentsSampleSystemApplicationExtensions
{
    public static IServiceCollection RegisterGeneralApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddMediatR(Assembly.GetAssembly(typeof(EmployeeBLL)))
                       .RegisterApplicationServices()
                       .AddLogging()
                       .AddCapBss(configuration.GetConnectionString("DefaultConnection"));
    }

    private static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<CustomAttachmentSecurityService>();

        return services;
    }
}
