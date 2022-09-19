using System;

using Framework.Authorization.BLL;
using Framework.Core;
using Framework.DomainDriven;
using Framework.DomainDriven.BLL;
using Framework.SecuritySystem.Rules.Builders;
using Framework.DomainDriven.BLL.Tracking;
using Framework.HierarchicalExpand;
using Framework.QueryLanguage;
using Framework.SecuritySystem;
using Framework.Attachments.BLL;

using JetBrains.Annotations;

using AttachmentsSampleSystem.Domain;

namespace AttachmentsSampleSystem.BLL
{
    public partial class AttachmentsSampleSystemBLLContext
    {
        public AttachmentsSampleSystemBLLContext(
            IServiceProvider serviceProvider,
            [NotNull] IOperationEventSenderContainer<PersistentDomainObjectBase> operationSenders,
            [NotNull] IObjectStateService objectStateService,
            [NotNull] IAccessDeniedExceptionService<PersistentDomainObjectBase> accessDeniedExceptionService,
            [NotNull] IStandartExpressionBuilder standartExpressionBuilder,
            [NotNull] IAttachmentsSampleSystemValidator validator,
            [NotNull] IHierarchicalObjectExpanderFactory<Guid> hierarchicalObjectExpanderFactory,
            [NotNull] IFetchService<PersistentDomainObjectBase, FetchBuildRule> fetchService,
            [NotNull] IAttachmentsSampleSystemSecurityService securityService,
            [NotNull] ISecurityExpressionBuilderFactory<PersistentDomainObjectBase, Guid> securityExpressionBuilderFactory,
            [NotNull] IAttachmentsSampleSystemBLLFactoryContainer logics,
            [NotNull] IAuthorizationBLLContext authorization,
            [NotNull] Framework.Configuration.BLL.IConfigurationBLLContext configuration,
            [NotNull] IAttachmentsBLLContext attachments,
            [NotNull] IAttachmentsSampleSystemBLLContextSettings settings)
            : base(serviceProvider, operationSenders, objectStateService, accessDeniedExceptionService, standartExpressionBuilder, validator, hierarchicalObjectExpanderFactory, fetchService)
        {
            this.SecurityExpressionBuilderFactory = securityExpressionBuilderFactory ?? throw new ArgumentNullException(nameof(securityExpressionBuilderFactory));

            this.SecurityService = securityService ?? throw new ArgumentNullException(nameof(securityService));
            this.Logics = logics ?? throw new ArgumentNullException(nameof(logics));

            this.Authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
            this.Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.Attachments = attachments ?? throw new ArgumentNullException(nameof(attachments));

            this.TypeResolver = settings.TypeResolver;
        }

        public IAttachmentsSampleSystemSecurityService SecurityService { get; }

        public ISecurityExpressionBuilderFactory<PersistentDomainObjectBase, Guid> SecurityExpressionBuilderFactory { get; }

        public override IAttachmentsSampleSystemBLLFactoryContainer Logics { get; }

        public IAuthorizationBLLContext Authorization { get; }

        public Framework.Configuration.BLL.IConfigurationBLLContext Configuration { get; }

        public IAttachmentsBLLContext Attachments { get; }

        public ITypeResolver<string> TypeResolver { get; }

        ITypeResolver<string> ISecurityTypeResolverContainer.SecurityTypeResolver => this.TypeResolver;
    }
}
