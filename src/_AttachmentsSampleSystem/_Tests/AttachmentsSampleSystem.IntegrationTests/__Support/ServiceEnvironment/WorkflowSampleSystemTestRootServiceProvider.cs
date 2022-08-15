using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using Framework.Cap.Abstractions;
using Framework.DomainDriven;
using Framework.DomainDriven.NHibernate.Audit;
using Framework.DomainDriven.ServiceModel.IAD;
using Framework.DomainDriven.WebApiNetCore;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

using AttachmentsSampleSystem.BLL;
using AttachmentsSampleSystem.IntegrationTests.__Support.ServiceEnvironment.IntegrationTests;
using AttachmentsSampleSystem.IntegrationTests.__Support.TestData.Helpers;
using AttachmentsSampleSystem.ServiceEnvironment;
using AttachmentsSampleSystem.WebApiCore;
using AttachmentsSampleSystem.WebApiCore.Env;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

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
                                .AddInMemoryCollection(new Dictionary<string, string>
                                 {
                                         {
                                                 "ConnectionStrings:DefaultConnection",
                                                 InitializeAndCleanup.DatabaseUtil.ConnectionSettings.ConnectionString
                                         },
                                 })
                                .Build();

            return new ServiceCollection()

                                  .AddEnvironment(configuration)

                                  .RegisterLegacyBLLContext()
                                  .AddControllerEnvironment()

                                  .AddMediatR(Assembly.GetAssembly(typeof(EmployeeBLL)))

                                  .RegisterControllers()

                                  .AddScoped<IntegrationTestsWebApiCurrentMethodResolver>()
                                  .ReplaceScopedFrom<IWebApiCurrentMethodResolver, IntegrationTestsWebApiCurrentMethodResolver>()

                                  .ReplaceSingleton<IWebApiExceptionExpander, WebApiDebugExceptionExpander>()

                                  .AddSingleton<IntegrationTestDefaultUserAuthenticationService>()
                                  .ReplaceSingletonFrom<IDefaultUserAuthenticationService, IntegrationTestDefaultUserAuthenticationService>()
                                  .ReplaceSingletonFrom<IAuditRevisionUserAuthenticationService, IntegrationTestDefaultUserAuthenticationService>()

                                  .ReplaceSingleton<IDateTimeService, IntegrationTestDateTimeService>()

                                  .AddSingleton<ICapTransactionManager, TestCapTransactionManager>()
                                  .AddSingleton<IIntegrationEventBus, TestIntegrationEventBus>()


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
