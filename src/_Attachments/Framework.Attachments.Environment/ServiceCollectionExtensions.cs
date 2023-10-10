using Framework.Core;
using Framework.DomainDriven;
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
                   .AddSingleton<AttachmentsValidationMap>()
                   .AddSingleton<AttachmentsValidatorCompileCache>()
                   .AddScoped<IAttachmentsValidator, AttachmentsValidator>()

                   .AddSingleton(new AttachmentsMainFetchService().WithCompress().WithCache().WithLock().Add(FetchService<Framework.Attachments.Domain.PersistentDomainObjectBase>.OData))
                   .AddScoped<IAttachmentsBLLFactoryContainer, AttachmentsBLLFactoryContainer>()
                   .AddScoped<IAttachmentsBLLContextSettings, AttachmentsBLLContextSettings>()

                   .AddScopedFromLazyInterfaceImplement<IAttachmentsBLLContext, AttachmentsBLLContext>()

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
