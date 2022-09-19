using System;

using Framework.Core;
using Framework.DomainDriven;
using Framework.DomainDriven.BLL;
using Framework.QueryableSource;
using Framework.SecuritySystem;
using Framework.SecuritySystem.Rules.Builders;
using Framework.Attachments.BLL;
using Framework.Attachments.Generated.DTO;
using Framework.DependencyInjection;

using Microsoft.Extensions.DependencyInjection;
using Framework.DomainDriven.ServiceModel.Service;
using Framework.DomainDriven.WebApiNetCore;

namespace Framework.Attachments.ServiceEnvironment
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterAttachmentsBLL(this IServiceCollection services)
        {
            return services

                   .AddSingleton<AttachmentsValidatorCompileCache>()

                   .AddScoped<IAttachmentsValidator, AttachmentsValidator>()

                   .AddSingleton(new AttachmentsMainFetchService().WithCompress().WithCache().WithLock().Add(FetchService<Framework.Attachments.Domain.PersistentDomainObjectBase>.OData))
                   .AddScoped<IAttachmentsSecurityService, AttachmentsSecurityService>()
                   .AddScoped<IAttachmentsBLLFactoryContainer, AttachmentsBLLFactoryContainer>()

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

        public static IServiceCollection RegisterAttachmentsWebApiGenericServices(this IServiceCollection services)
        {
            services.RegisterAttachmentsContextEvaluator();

            return services;
        }

        private static IServiceCollection RegisterAttachmentsContextEvaluator(this IServiceCollection services)
        {
            services.AddSingleton<IContextEvaluator<IAttachmentsBLLContext>, ContextEvaluator<IAttachmentsBLLContext>>();
            services.AddScoped<IApiControllerBaseEvaluator<EvaluatedData<IAttachmentsBLLContext, IAttachmentsDTOMappingService>>, ApiControllerBaseSingleCallEvaluator<EvaluatedData<IAttachmentsBLLContext, IAttachmentsDTOMappingService>>>();

            return services;
        }
    }
}
