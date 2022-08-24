using System;
using System.Collections.Generic;

using Framework.Authorization;
using Framework.Authorization.BLL;
using Framework.Authorization.Events;
using Framework.Authorization.Generated.DTO;
using Framework.Configuration.BLL;
using Framework.Configuration.BLL.Notification;
using Framework.Configuration.Generated.DTO;
using Framework.Core;
using Framework.DomainDriven;
using Framework.DomainDriven.BLL;
using Framework.DomainDriven.NHibernate;
using Framework.DomainDriven.ServiceModel.IAD;
using Framework.DomainDriven.ServiceModel.Service;
using Framework.Events;

using Framework.HierarchicalExpand;
using Framework.QueryableSource;
using Framework.SecuritySystem;
using Framework.SecuritySystem.Rules.Builders;
using Framework.Attachments.BLL;
using Framework.Attachments.Generated.DTO;
using Framework.Attachments.ServiceEnvironment;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using AttachmentsSampleSystem.BLL;
using AttachmentsSampleSystem.Domain;
using AttachmentsSampleSystem.Generated.DTO;
using AttachmentsSampleSystem.ServiceEnvironment;

using TargetSystemServiceFactory = Framework.Attachments.BLL.TargetSystemServiceFactory;

namespace AttachmentsSampleSystem.WebApiCore;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterLegacyBLLContext(this IServiceCollection services)
    {
        services.AddScoped<TargetSystemServiceFactory>();

        services.AddScoped<CustomAttachmentSecurityService>();

        services.AddScoped(sp => sp.GetRequiredService<TargetSystemServiceFactory>().Create(tss => tss.IsMain, sp => sp.GetRequiredService<CustomAttachmentSecurityService>()));

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

        services.AddSingleton(AvailableValuesHelper.AvailableValues.ToValidation());

        services.AddSingleton<IDefaultMailSenderContainer>(new DefaultMailSenderContainer("AttachmentsSampleSystem_Sender@luxoft.com"));

        services.AddScoped<IBLLSimpleQueryBase<Framework.Persistent.IEmployee>>(sp => sp.GetRequiredService<IEmployeeBLLFactory>().Create());

        services.RegisterHierarchicalObjectExpander();

        services.RegisterAdditonalAuthorizationBLL();


        services.RegisterGenericServices();
        services.RegisterAuthorizationSystem();

        services.RegisterAuthorizationBLL();
        services.RegisterConfigurationBLL();
        services.RegisterAttachmentsBLL();
        services.RegisterMainBLL();

        return services;
    }

    public static IServiceCollection RegisterHierarchicalObjectExpander(this IServiceCollection services)
    {
        return services.AddSingleton<IHierarchicalRealTypeResolver, ProjectionHierarchicalRealTypeResolver>()
                       .AddScoped<IHierarchicalObjectExpanderFactory<Guid>, HierarchicalObjectExpanderFactory<PersistentDomainObjectBase, Guid>>();
    }

    public static IServiceCollection RegisterAdditonalAuthorizationBLL(this IServiceCollection services)
    {
        return services.AddScopedFrom<ISecurityTypeResolverContainer, IAttachmentsSampleSystemBLLContext>()
                       .AddScoped<IAuthorizationExternalSource, AuthorizationExternalSource<IAttachmentsSampleSystemBLLContext, PersistentDomainObjectBase, AuditPersistentDomainObjectBase, AttachmentsSampleSystemSecurityOperationCode>>();
    }

    public static IServiceCollection RegisterMainBLL(this IServiceCollection services)
    {
        return services

                .AddScoped(sp => sp.GetRequiredService<IDBSession>().GetDALFactory<PersistentDomainObjectBase, Guid>())
                
                .AddSingleton<AttachmentsSampleSystemValidatorCompileCache>()

                .AddScoped<IAttachmentsSampleSystemValidator>(sp =>
                     new AttachmentsSampleSystemValidator(sp.GetRequiredService<IAttachmentsSampleSystemBLLContext>(), sp.GetRequiredService<AttachmentsSampleSystemValidatorCompileCache>()))

                .AddSingleton(new AttachmentsSampleSystemMainFetchService().WithCompress().WithCache().WithLock().Add(FetchService<PersistentDomainObjectBase>.OData))
                .AddScoped<IAttachmentsSampleSystemSecurityService, AttachmentsSampleSystemSecurityService>()
                .AddScoped<IAttachmentsSampleSystemBLLFactoryContainer, AttachmentsSampleSystemBLLFactoryContainer>()
                .AddScoped<IAttachmentsSampleSystemBLLContextSettings>(_ => new AttachmentsSampleSystemBLLContextSettings { TypeResolver  = new[] { new AttachmentsSampleSystemBLLContextSettings().TypeResolver, TypeSource.FromSample<BusinessUnitSimpleDTO>().ToDefaultTypeResolver() }.ToComposite() })
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

    public static IServiceCollection RegisterDependencyInjections(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEnvironment(configuration);

        return services;
    }
}
