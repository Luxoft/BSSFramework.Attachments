using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using Framework.Authorization.BLL;
using Framework.Cap.Abstractions;
using Framework.Core.Services;
using Framework.DomainDriven;
using Framework.DomainDriven.NHibernate.Audit;
using Framework.DomainDriven.ServiceModel.IAD;
using Framework.DomainDriven.WebApiNetCore;
using Framework.Exceptions;

using MediatR;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using nuSpec.Abstraction;
using nuSpec.NHibernate;

using AttachmentsSampleSystem.BLL;
using AttachmentsSampleSystem.IntegrationTests.__Support.ServiceEnvironment.IntegrationTests;
using AttachmentsSampleSystem.IntegrationTests.__Support.TestData.Helpers;
using AttachmentsSampleSystem.ServiceEnvironment;
using AttachmentsSampleSystem.WebApiCore;
using AttachmentsSampleSystem.WebApiCore.Env;

namespace AttachmentsSampleSystem.IntegrationTests.__Support.ServiceEnvironment
{
    public static class AttachmentsSampleSystemTestRootServiceProvider
    {
        public static readonly IServiceProvider Default = CreateDefault();

        private static IServiceProvider CreateDefault()
        {
            var serviceProvider = BuildServiceProvider();

            return serviceProvider;
        }


        private static IServiceProvider BuildServiceProvider()
        {
            var configuration = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", false, true)
                                .AddEnvironmentVariables(nameof(AttachmentsSampleSystem) + "_")
                                .Build();


            return new ServiceCollection()
                                  .RegisterLegacyBLLContext()
                                  .RegisterControllers()
                                  .AddControllerEnvironment()

                                  .AddMediatR(Assembly.GetAssembly(typeof(EmployeeBLL)))

                                  .AddSingleton<IntegrationTestDefaultUserAuthenticationService>()
                                  .AddSingletonFrom<IDefaultUserAuthenticationService, IntegrationTestDefaultUserAuthenticationService>()
                                  .AddSingletonFrom<IAuditRevisionUserAuthenticationService, IntegrationTestDefaultUserAuthenticationService>()

                                  .AddScoped<AttachmentsSampleSystemUserAuthenticationService>()
                                  .AddScopedFrom<IUserAuthenticationService, AttachmentsSampleSystemUserAuthenticationService>()
                                  .AddScopedFrom<IImpersonateService, AttachmentsSampleSystemUserAuthenticationService>()

                                  .AddSingleton<IDateTimeService, IntegrationTestDateTimeService>()
                                  .AddDatabaseSettings(InitializeAndCleanup.DatabaseUtil.ConnectionSettings.ConnectionString)
                                  .AddScoped<IExceptionProcessor, ApiControllerExceptionService<IAttachmentsSampleSystemBLLContext>>()
                                  .AddSingleton<ISpecificationEvaluator, NhSpecificationEvaluator>()
                                  .AddSingleton<ICapTransactionManager, TestCapTransactionManager>()
                                  .AddSingleton<IIntegrationEventBus, TestIntegrationEventBus>()

                                  .AddSingleton<TestDebugModeManager>()
                                  .AddSingleton<AttachmentsSampleSystemInitializer>()

                                  .BuildServiceProvider(new ServiceProviderOptions { ValidateOnBuild = true, ValidateScopes = true });
        }


        private class TestCapTransactionManager : ICapTransactionManager
        {
            public void Enlist(IDbTransaction dbTransaction)
            {
            }
        }

        private class TestIntegrationEventBus : IIntegrationEventBus
        {
            public Task PublishAsync(IntegrationEvent @event, CancellationToken cancellationToken) => Task.CompletedTask;

            public void Publish(IntegrationEvent @event)
            {
            }
        }
    }
}
