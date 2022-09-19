using System;

using Framework.Authorization;
using Framework.Authorization.BLL;
using Framework.Authorization.Events;
using Framework.Authorization.Generated.DTO;
using Framework.Configuration.BLL;
using Framework.Configuration.BLL.Notification;
using Framework.Configuration.BLL.SubscriptionSystemService3.Subscriptions;
using Framework.Configuration.Generated.DTO;
using Framework.Core;
using Framework.DependencyInjection;
using Framework.DomainDriven;
using Framework.DomainDriven.BLL;
using Framework.DomainDriven.Serialization;
using Framework.DomainDriven.SerializeMetadata;
using Framework.DomainDriven.ServiceModel.IAD;
using Framework.DomainDriven.ServiceModel.Service;
using Framework.DomainDriven.WebApiNetCore;
using Framework.Events;
using Framework.Persistent;
using Framework.QueryableSource;
using Framework.SecuritySystem;
using Framework.SecuritySystem.Rules.Builders;
using Framework.Attachments.BLL;
using Framework.Attachments.Generated.DTO;
using Framework.Attachments.ServiceEnvironment;

using Microsoft.Extensions.DependencyInjection;

using AttachmentsSampleSystem.BLL;
using AttachmentsSampleSystem.Domain;
using AttachmentsSampleSystem.Generated.DTO;

namespace AttachmentsSampleSystem.ServiceEnvironment;

public static class AttachmentsSampleSystemFrameworkExtensions
{
    public static IServiceCollection RegisterGeneralBssFramework(this IServiceCollection services)
    {
        return services.RegisterGenericServices()
                       .RegisterWebApiGenericServices()
                       .RegisterAttachmentsBLL()
                       .RegisterAttachmentsWebApiGenericServices()

                       .RegisterMainBLLContext()
                       .RegisterAttachmentsTargetSystems()
                       .RegisterListeners()
                       .RegisterContextEvaluator()

                       .RegisterSupportServices();
    }

    private static IServiceCollection RegisterMainBLLContext(this IServiceCollection services)
    {
        return services

               .AddSingleton<AttachmentsSampleSystemValidatorCompileCache>()

               .AddScoped<IAttachmentsSampleSystemValidator, AttachmentsSampleSystemValidator>()

               .AddSingleton(new AttachmentsSampleSystemMainFetchService().WithCompress().WithCache().WithLock().Add(FetchService<PersistentDomainObjectBase>.OData))
               .AddScoped<IAttachmentsSampleSystemSecurityService, AttachmentsSampleSystemSecurityService>()
               .AddScoped<IAttachmentsSampleSystemBLLFactoryContainer, AttachmentsSampleSystemBLLFactoryContainer>()
               .AddScoped<IAttachmentsSampleSystemBLLContextSettings>(_ => new AttachmentsSampleSystemBLLContextSettings { TypeResolver = new[] { new AttachmentsSampleSystemBLLContextSettings().TypeResolver, TypeSource.FromSample<BusinessUnitSimpleDTO>().ToDefaultTypeResolver() }.ToComposite() })
               .AddScopedFromLazyInterfaceImplement<IAttachmentsSampleSystemBLLContext, AttachmentsSampleSystemBLLContext>()

               .AddScopedFrom<ISecurityOperationResolver<PersistentDomainObjectBase, AttachmentsSampleSystemSecurityOperationCode>, IAttachmentsSampleSystemBLLContext>()
               .AddScopedFrom<IDisabledSecurityProviderContainer<PersistentDomainObjectBase>, IAttachmentsSampleSystemSecurityService>()
               .AddScopedFrom<IAttachmentsSampleSystemSecurityPathContainer, IAttachmentsSampleSystemSecurityService>()
               .AddScoped<IQueryableSource<PersistentDomainObjectBase>, BLLQueryableSource<IAttachmentsSampleSystemBLLContext, PersistentDomainObjectBase, DomainObjectBase, Guid>>()
               .AddScoped<ISecurityExpressionBuilderFactory<PersistentDomainObjectBase, Guid>, Framework.SecuritySystem.Rules.Builders.MaterializedPermissions.SecurityExpressionBuilderFactory<PersistentDomainObjectBase, Guid>>()
               .AddScoped<IAccessDeniedExceptionService<PersistentDomainObjectBase>, AccessDeniedExceptionService<PersistentDomainObjectBase, Guid>>()

               .Self(AttachmentsSampleSystemSecurityServiceBase.Register)
               .Self(AttachmentsSampleSystemBLLFactoryContainer.RegisterBLLFactory);
    }

    private static IServiceCollection RegisterAttachmentsTargetSystems(this IServiceCollection services)
    {
        services.AddScoped<Framework.Attachments.BLL.TargetSystemServiceFactory>();
        services.AddScopedFrom((Framework.Attachments.BLL.TargetSystemServiceFactory factory) => factory.Create(tss => tss.IsMain, sp => sp.GetRequiredService<CustomAttachmentSecurityService>()));

        return services;
    }

    private static IServiceCollection RegisterListeners(this IServiceCollection services)
    {
        services.AddSingleton<IInitializeManager, InitializeManager>();

        services.AddScoped<IBeforeTransactionCompletedDALListener, DenormalizeHierarchicalDALListener<IAttachmentsSampleSystemBLLContext, PersistentDomainObjectBase, NamedLock, NamedLockOperation>>();
        services.AddScoped<IBeforeTransactionCompletedDALListener, FixDomainObjectEventRevisionNumberDALListener>();

        services.AddScoped<DefaultAuthDALListener>();

        services.AddScopedFrom<IBeforeTransactionCompletedDALListener, DefaultAuthDALListener>();
        services.AddScopedFrom<IManualEventDALListener<Framework.Authorization.Domain.PersistentDomainObjectBase>, DefaultAuthDALListener>();

        services.AddScoped<EvaluatedData<IAuthorizationBLLContext, IAuthorizationDTOMappingService>>();
        services.AddScoped<IAuthorizationDTOMappingService, AuthorizationServerPrimitiveDTOMappingService>();

        services.AddScoped<EvaluatedData<IConfigurationBLLContext, IConfigurationDTOMappingService>>();
        services.AddScoped<IConfigurationDTOMappingService, ConfigurationServerPrimitiveDTOMappingService>();

        services.AddScoped<EvaluatedData<IAttachmentsBLLContext, IAttachmentsDTOMappingService>>();
        services.AddScoped<IAttachmentsDTOMappingService, AttachmentsServerPrimitiveDTOMappingService>();

        services.AddScoped<EvaluatedData<IAttachmentsSampleSystemBLLContext, IAttachmentsSampleSystemDTOMappingService>>();
        services.AddScoped<IAttachmentsSampleSystemDTOMappingService, AttachmentsSampleSystemServerPrimitiveDTOMappingService>();

        services.AddScoped<IOperationEventSenderContainer<PersistentDomainObjectBase>, OperationEventSenderContainer<PersistentDomainObjectBase>>();

        services.AddScoped<IOperationEventListener<Framework.Authorization.Domain.PersistentDomainObjectBase>, AuthorizationEventsSubscriptionManager>();
        services.AddScoped<IMessageSender<IDomainOperationSerializeData<Framework.Authorization.Domain.PersistentDomainObjectBase>>, AuthorizationLocalDBEventMessageSender>();

        return services;
    }

    private static IServiceCollection RegisterContextEvaluator(this IServiceCollection services)
    {
        services.AddSingleton<IContextEvaluator<IAttachmentsSampleSystemBLLContext>, ContextEvaluator<IAttachmentsSampleSystemBLLContext>>();
        services.AddScoped<IApiControllerBaseEvaluator<EvaluatedData<IAttachmentsSampleSystemBLLContext, IAttachmentsSampleSystemDTOMappingService>>, ApiControllerBaseSingleCallEvaluator<EvaluatedData<IAttachmentsSampleSystemBLLContext, IAttachmentsSampleSystemDTOMappingService>>>();

        return services;
    }

    private static IServiceCollection RegisterSupportServices(this IServiceCollection services)
    {
        // For auth
        services.AddScopedFrom<ISecurityTypeResolverContainer, IAttachmentsSampleSystemBLLContext>();
        services.AddScoped<IAuthorizationExternalSource, AuthorizationExternalSource<IAttachmentsSampleSystemBLLContext, PersistentDomainObjectBase, AuditPersistentDomainObjectBase, AttachmentsSampleSystemSecurityOperationCode>>();

        // For notification
        services.AddSingleton<IDefaultMailSenderContainer>(new DefaultMailSenderContainer("AttachmentsSampleSystem_Sender@luxoft.com"));
        services.AddScopedFrom<IBLLSimpleQueryBase<IEmployee>, IEmployeeBLLFactory>(factory => factory.Create());

        // For expand tree
        services.RegisterHierarchicalObjectExpander<PersistentDomainObjectBase>();

        return services;
    }
}
