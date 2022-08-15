using Framework.Authorization.BLL;
using Framework.Authorization.Generated.DAL.NHibernate;
using Framework.Cap;
using Framework.Configuration.Generated.DAL.NHibernate;
using Framework.Core.Services;
using Framework.DependencyInjection;
using Framework.DomainDriven;
using Framework.DomainDriven.BLL;
using Framework.DomainDriven.NHibernate;
using Framework.DomainDriven.NHibernate.Audit;
using Framework.DomainDriven.ServiceModel.IAD;
using Framework.DomainDriven.WebApiNetCore;
using Framework.Exceptions;
using Framework.Attachments.Generated.DAL.NHibernate;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using nuSpec.Abstraction;
using nuSpec.NHibernate;

using AttachmentsSampleSystem.BLL;
using AttachmentsSampleSystem.Generated.DAL.NHibernate;
using AttachmentsSampleSystem.Generated.DTO;
using AttachmentsSampleSystem.WebApiCore.Env;
using AttachmentsSampleSystem.WebApiCore.Env.Database;

using Framework.Attachments.BLL;
using Framework.Attachments.Environment;
using Framework.Attachments.Generated.DTO;
using Framework.Authorization.Generated.DTO;
using Framework.Configuration.BLL;
using Framework.Configuration.Generated.DTO;
using Framework.DomainDriven.ServiceModel.Service;

namespace AttachmentsSampleSystem.WebApiCore
{
    public static class EnvironmentExtensions
    {
        public static IServiceCollection AddEnvironment(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddHttpContextAccessor();
            services.AddScoped<IWebApiDBSessionModeResolver, WebApiDBSessionModeResolver>();
            services.AddScoped<IWebApiCurrentMethodResolver, WebApiCurrentMethodResolver>();

            services.AddDatabaseSettings(connectionString);
            services.AddCapBss(connectionString);

            // Notifications
            services.RegisterMessageSenderDependencies<IAttachmentsSampleSystemBLLContext>(configuration);
            services.RegisterRewriteReceiversDependencies(configuration);

            // Others
            services.AddSingleton<IDateTimeService>(DateTimeService.Default);

            services.AddSingleton<AttachmentsSampleSystemDefaultUserAuthenticationService>();
            services.AddSingletonFrom<IDefaultUserAuthenticationService, AttachmentsSampleSystemDefaultUserAuthenticationService>();
            services.AddSingletonFrom<IAuditRevisionUserAuthenticationService, AttachmentsSampleSystemDefaultUserAuthenticationService>();

            services.AddScoped<AttachmentsSampleSystemUserAuthenticationService>();
            services.AddScopedFrom<IUserAuthenticationService, AttachmentsSampleSystemUserAuthenticationService>();
            services.AddScopedFrom<IUserAuthenticationService, AttachmentsSampleSystemUserAuthenticationService>();

            services.AddSingleton<ISpecificationEvaluator, NhSpecificationEvaluator>();

            services.AddLogging();

            return services.AddControllerEnvironment();
        }

        public static IServiceCollection AddDatabaseSettings(this IServiceCollection services, string connectionString) =>
                services.AddScoped<INHibSessionSetup, NHibSessionSettings>()

                        .AddScoped<IDBSessionEventListener, DefaultDBSessionEventListener>()
                        .AddScoped<IDBSessionEventListener, AttachmentsDBSessionEventListener>()
                        .AddScopedFromLazy<IDBSession, NHibSession>()

                        .AddSingleton<INHibSessionEnvironmentSettings, NHibSessionEnvironmentSettings>()
                        .AddSingleton<NHibConnectionSettings>()
                        .AddSingleton<NHibSessionEnvironment, AttachmentsSampleSystemNHibSessionEnvironment>()

                        .AddSingleton<IMappingSettings>(AuthorizationMappingSettings.CreateDefaultAudit(string.Empty))
                        .AddSingleton<IMappingSettings>(ConfigurationMappingSettings.CreateDefaultAudit(string.Empty))
                        .AddSingleton<IMappingSettings>(AttachmentsMappingSettings.CreateWithoutAudit(string.Empty))
                        .AddSingleton<IMappingSettings>(
                                                        new AttachmentsSampleSystemMappingSettings(
                                                         new DatabaseName(string.Empty, "app"),
                                                         connectionString));

        public static IServiceCollection AddControllerEnvironment(this IServiceCollection services)
        {
            services.AddSingleton<IWebApiExceptionExpander, WebApiExceptionExpander>();

            services.AddSingleton<IDBSessionEvaluator, DBSessionEvaluator>();

            services.AddSingleton<IContextEvaluator<IAuthorizationBLLContext>, ContextEvaluator<IAuthorizationBLLContext>>();
            services.AddSingleton<IContextEvaluator<IConfigurationBLLContext>, ContextEvaluator<IConfigurationBLLContext>>();
            services.AddSingletonFrom<IContextEvaluator<Framework.DomainDriven.BLL.Configuration.IConfigurationBLLContext>, IContextEvaluator<IConfigurationBLLContext>>();
            services.AddSingleton<IContextEvaluator<IAttachmentsSampleSystemBLLContext>, ContextEvaluator<IAttachmentsSampleSystemBLLContext>>();
            services.AddSingleton<IContextEvaluator<IAttachmentsBLLContext>, ContextEvaluator<IAttachmentsBLLContext>>();


            services.AddScoped<IApiControllerBaseEvaluator<EvaluatedData<IAuthorizationBLLContext, IAuthorizationDTOMappingService>>, ApiControllerBaseSingleCallEvaluator<EvaluatedData<IAuthorizationBLLContext, IAuthorizationDTOMappingService>>>();
            services.AddScoped<IApiControllerBaseEvaluator<EvaluatedData<IConfigurationBLLContext, IConfigurationDTOMappingService>>, ApiControllerBaseSingleCallEvaluator<EvaluatedData<IConfigurationBLLContext, IConfigurationDTOMappingService>>>();
            services.AddScoped<IApiControllerBaseEvaluator<EvaluatedData<IAttachmentsBLLContext, IAttachmentsDTOMappingService>>, ApiControllerBaseSingleCallEvaluator<EvaluatedData<IAttachmentsBLLContext, IAttachmentsDTOMappingService>>>();
            services.AddScoped<IApiControllerBaseEvaluator<EvaluatedData<IAttachmentsSampleSystemBLLContext, IAttachmentsSampleSystemDTOMappingService>>, ApiControllerBaseSingleCallEvaluator<EvaluatedData<IAttachmentsSampleSystemBLLContext, IAttachmentsSampleSystemDTOMappingService>>>();


            return services;
        }
    }
}
