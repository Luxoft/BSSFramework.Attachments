using System;
using System.Collections.Generic;
using System.Linq;

using Framework.Attachments.Domain;
using Framework.Core;
using Framework.DomainDriven.BLL.Security;
using Framework.Persistent;

using Microsoft.Extensions.DependencyInjection;

namespace Framework.Attachments.BLL;

public class TargetSystemServiceFactory
{
    private readonly IServiceProvider serviceProvider;

    private readonly Lazy<List<TargetSystem>> lazyTargetSystems;

    public TargetSystemServiceFactory(IServiceProvider serviceProvider, IAttachmentsBLLContext context)
    {
        this.serviceProvider = serviceProvider;

        this.lazyTargetSystems = LazyHelper.Create(() => context.Logics.TargetSystem.GetFullList());
    }

    public ITargetSystemService Create<TBLLContext, TPersistentDomainObjectBase>(string name)
            where TBLLContext : class, ITypeResolverContainer<string>, ISecurityServiceContainer<IRootSecurityService<TPersistentDomainObjectBase>>, ISecurityBLLContext<TPersistentDomainObjectBase, Guid>
            where TPersistentDomainObjectBase : class, IIdentityObject<Guid>
    {
        return this.Create<TBLLContext, TPersistentDomainObjectBase>(tss => tss.Name == name);
    }

    public ITargetSystemService Create<TBLLContext, TPersistentDomainObjectBase>(Func<TargetSystem, bool> filter)
            where TBLLContext : class, ITypeResolverContainer<string>, ISecurityServiceContainer<IRootSecurityService<TPersistentDomainObjectBase>>, ISecurityBLLContext<TPersistentDomainObjectBase, Guid>
            where TPersistentDomainObjectBase : class, IIdentityObject<Guid>
    {
        return LazyInterfaceImplementHelper<ITargetSystemService>.CreateProxy(() =>
        {
            var targetSystem = this.lazyTargetSystems.Value.Single(filter);

            return ActivatorUtilities.CreateInstance<TargetSystemService<TBLLContext, TPersistentDomainObjectBase>>(this.serviceProvider, targetSystem);
        });
    }
}
