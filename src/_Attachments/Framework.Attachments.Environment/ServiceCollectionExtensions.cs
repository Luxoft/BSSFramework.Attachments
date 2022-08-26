using System;

using Framework.Core;
using Framework.DomainDriven;
using Framework.DomainDriven.BLL;
using Framework.QueryableSource;
using Framework.SecuritySystem;
using Framework.SecuritySystem.Rules.Builders;
using Framework.Attachments.BLL;
using Framework.DependencyInjection;

using Microsoft.Extensions.DependencyInjection;

namespace Framework.Attachments.ServiceEnvironment
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterAttachmentsBLL(this IServiceCollection services)
        {
            return services

                   .AddScopedFrom((IDBSession session) => session.GetDALFactory<Framework.Attachments.Domain.PersistentDomainObjectBase, Guid>())

                   .AddScoped<IOperationEventSenderContainer<Framework.Attachments.Domain.PersistentDomainObjectBase>, OperationEventSenderContainer<Framework.Attachments.Domain.PersistentDomainObjectBase>>()

                   .AddSingleton<AttachmentsValidatorCompileCache>()

                   .AddScoped<IAttachmentsValidator>(sp =>
                                                          new AttachmentsValidator(sp.GetRequiredService<IAttachmentsBLLContext>(), sp.GetRequiredService<AttachmentsValidatorCompileCache>()))


                   .AddSingleton(new AttachmentsMainFetchService().WithCompress().WithCache().WithLock().Add(FetchService<Framework.Attachments.Domain.PersistentDomainObjectBase>.OData))
                   .AddScoped<IAttachmentsSecurityService, AttachmentsSecurityService>()
                   .AddScoped<IAttachmentsBLLFactoryContainer, AttachmentsBLLFactoryContainer>()

                   .AddScopedFrom<ICurrentRevisionService, IDBSession>()

                   .AddScoped<IAttachmentsBLLContextSettings, AttachmentsBLLContextSettings>()
                   .AddScopedFromLazyInterfaceImplement<IAttachmentsBLLContext, AttachmentsBLLContext>()

                   .AddScopedFrom<ISecurityOperationResolver<Framework.Attachments.Domain.PersistentDomainObjectBase, Framework.Attachments.AttachmentsSecurityOperationCode>, IAttachmentsBLLContext>()
                   .AddScopedFrom<IDisabledSecurityProviderContainer<Framework.Attachments.Domain.PersistentDomainObjectBase>, IAttachmentsSecurityService>()
                   .AddScopedFrom<IAttachmentsSecurityPathContainer, IAttachmentsSecurityService>()
                   .AddScoped<IQueryableSource<Framework.Attachments.Domain.PersistentDomainObjectBase>, BLLQueryableSource<IAttachmentsBLLContext, Framework.Attachments.Domain.PersistentDomainObjectBase, Framework.Attachments.Domain.DomainObjectBase, Guid>>()
                   .AddScoped<ISecurityExpressionBuilderFactory<Framework.Attachments.Domain.PersistentDomainObjectBase, Guid>, Framework.SecuritySystem.Rules.Builders.MaterializedPermissions.SecurityExpressionBuilderFactory<Framework.Attachments.Domain.PersistentDomainObjectBase, Guid>>()
                   .AddScoped<IAccessDeniedExceptionService<Framework.Attachments.Domain.PersistentDomainObjectBase>, AccessDeniedExceptionService<Framework.Attachments.Domain.PersistentDomainObjectBase, Guid>>()

                   .Self(AttachmentsSecurityServiceBase.Register)
                   .Self(AttachmentsBLLFactoryContainer.RegisterBLLFactory);
        }
    }
}
