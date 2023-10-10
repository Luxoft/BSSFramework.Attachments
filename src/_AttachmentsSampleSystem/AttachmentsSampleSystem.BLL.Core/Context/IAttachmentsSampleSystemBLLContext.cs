using System;

using Framework.Authorization.BLL;
using Framework.Core;
using Framework.DomainDriven.BLL;
using Framework.Attachments.BLL;

using AttachmentsSampleSystem.Domain;

using Framework.DomainDriven.BLL.Security;
using Framework.DomainDriven.Tracking;

namespace AttachmentsSampleSystem.BLL
{
    public partial interface IAttachmentsSampleSystemBLLContext :

        ISecurityBLLContext<IAuthorizationBLLContext, PersistentDomainObjectBase, Guid>,

        IAttachmentsBLLContextContainer,

        ITrackingServiceContainer<PersistentDomainObjectBase>,

        ITypeResolverContainer<string>,

        Framework.DomainDriven.BLL.Configuration.IConfigurationBLLContextContainer<Framework.Configuration.BLL.IConfigurationBLLContext>,

        IDefaultHierarchicalBLLContext<PersistentDomainObjectBase, Guid>
    {
    }
}
