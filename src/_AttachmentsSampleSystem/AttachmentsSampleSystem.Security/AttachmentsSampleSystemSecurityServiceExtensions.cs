using System;

using AttachmentsSampleSystem.Domain;

using Framework.SecuritySystem;

using Microsoft.Extensions.DependencyInjection;

using Framework.SecuritySystem.DependencyInjection;
using Framework.SecuritySystem.DependencyInjection.DomainSecurityServiceBuilder;
using Framework.Authorization.SecuritySystem;

namespace AttachmentsSampleSystem.Security;

public static class AttachmentsSampleSystemSecurityServiceExtensions
{
    public static IServiceCollection RegisterGeneralSecurityServices(this IServiceCollection services)
    {
        return services.RegisterSecurityContexts()
                       .RegisterSecurityOperations()
                       .RegisterSecurityRoles()
                       .RegisterDomainSecurityServices();
    }

    private static IServiceCollection RegisterSecurityContexts(this IServiceCollection services)
    {
        return services.RegisterSecurityContextInfoService<Guid>(
                                                                 b => b.Add<BusinessUnit>(new Guid("263D2C60-7BCE-45D6-A0AF-A0830152353E"))
                                                                       .Add<Location>(new Guid("4641395B-9079-448E-9CB8-A083015235A3")));
    }

    private static IServiceCollection RegisterSecurityOperations(this IServiceCollection services)
    {
        return services.AddSingleton(new SecurityOperationTypeInfo(typeof(AttachmentsSampleSystemSecurityOperation)));
    }

    private static IServiceCollection RegisterSecurityRoles(this IServiceCollection services)
    {
        return services.AddSingleton(new SecurityRoleTypeInfo(typeof(AttachmentsSampleSystemSecurityRole)));
    }

    private static IServiceCollection RegisterDomainSecurityServices(this IServiceCollection services)
    {
        return services.RegisterMainDomainSecurityServices();
    }
    private static IServiceCollection RegisterMainDomainSecurityServices(this IServiceCollection services)
    {
        return services.RegisterDomainSecurityServices<Guid>(

                                                             rb =>

                                                                     rb.Add(AttachmentsSampleSystemSecurityOperation.EmployeeView,
                                                                            AttachmentsSampleSystemSecurityOperation.EmployeeEdit,
                                                                            SecurityPath<Employee>.Create(v => v.CoreBusinessUnit))

                                                                       .Add(AttachmentsSampleSystemSecurityOperation.BusinessUnitView,
                                                                            AttachmentsSampleSystemSecurityOperation.BusinessUnitEdit,
                                                                            SecurityPath<BusinessUnit>.Create(fbu => fbu))

                                                                       .Add<HRDepartment>(
                                                                        b => b.SetView(AttachmentsSampleSystemSecurityOperation.HRDepartmentView)
                                                                              .SetEdit(AttachmentsSampleSystemSecurityOperation.HRDepartmentEdit))

                                                                       .Add<Location>(
                                                                        b => b.SetView(AttachmentsSampleSystemSecurityOperation.LocationView)
                                                                              .SetEdit(AttachmentsSampleSystemSecurityOperation.LocationEdit)));
    }
}
