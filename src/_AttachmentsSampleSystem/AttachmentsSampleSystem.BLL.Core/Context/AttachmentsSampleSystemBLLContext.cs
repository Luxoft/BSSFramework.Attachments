using System;

using Framework.Authorization.BLL;
using Framework.Core;
using Framework.DomainDriven;
using Framework.DomainDriven.BLL;
using Framework.HierarchicalExpand;
using Framework.QueryLanguage;
using Framework.SecuritySystem;
using Framework.Attachments.BLL;

using AttachmentsSampleSystem.Domain;

using Framework.DomainDriven.BLL.Security;
using Framework.DomainDriven.Tracking;

namespace AttachmentsSampleSystem.BLL
{
    public partial class AttachmentsSampleSystemBLLContext
    {
        public AttachmentsSampleSystemBLLContext(
            IServiceProvider serviceProvider,
            IOperationEventSenderContainer<PersistentDomainObjectBase> operationSenders,
            ITrackingService<PersistentDomainObjectBase> trackingService,
            IAccessDeniedExceptionService accessDeniedExceptionService,
            IStandartExpressionBuilder standartExpressionBuilder,
            IAttachmentsSampleSystemValidator validator,
            IHierarchicalObjectExpanderFactory<Guid> hierarchicalObjectExpanderFactory,
            IFetchService<PersistentDomainObjectBase, FetchBuildRule> fetchService,
            IRootSecurityService<PersistentDomainObjectBase> securityService,
            IAttachmentsSampleSystemBLLFactoryContainer logics,
            IAuthorizationBLLContext authorization,
            Framework.Configuration.BLL.IConfigurationBLLContext configuration,
            IAttachmentsBLLContext attachments,
            IAttachmentsSampleSystemBLLContextSettings settings)
            : base(serviceProvider, operationSenders, trackingService, accessDeniedExceptionService, standartExpressionBuilder, validator, hierarchicalObjectExpanderFactory, fetchService)
        {
            this.SecurityService = securityService ?? throw new ArgumentNullException(nameof(securityService));
            this.Logics = logics ?? throw new ArgumentNullException(nameof(logics));

            this.Authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
            this.Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.Attachments = attachments ?? throw new ArgumentNullException(nameof(attachments));

            this.TypeResolver = settings.TypeResolver;
        }

        public IRootSecurityService<PersistentDomainObjectBase> SecurityService { get; }

        public override IAttachmentsSampleSystemBLLFactoryContainer Logics { get; }

        public IAuthorizationBLLContext Authorization { get; }

        public Framework.Configuration.BLL.IConfigurationBLLContext Configuration { get; }

        public IAttachmentsBLLContext Attachments { get; }

        public ITypeResolver<string> TypeResolver { get; }
    }
}
