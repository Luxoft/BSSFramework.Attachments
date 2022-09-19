using System;

using Framework.Cap.Abstractions;

using Microsoft.Extensions.DependencyInjection;

using AttachmentsSampleSystem.IntegrationTests.__Support.TestData.Helpers;
using AttachmentsSampleSystem.ServiceEnvironment;

using Microsoft.Extensions.Configuration;

using System.Collections.Generic;

using AttachmentsSampleSystem.WebApiCore.Controllers.Main;

using Automation.ServiceEnvironment;
using Automation.ServiceEnvironment.Services;
using Automation.Utils;
using Automation.Utils.DatabaseUtils.Interfaces;
using Framework.DependencyInjection;

namespace AttachmentsSampleSystem.IntegrationTests.__Support
{
    public static class AttachmentsSampleSystemTestRootServiceProvider
    {
        public static IServiceProvider Create(IConfiguration configurationBase, IDatabaseContext databaseContext, ConfigUtil configUtil)
        {
            var configuration = new ConfigurationBuilder()
                                .AddConfiguration(configurationBase)
                                .AddInMemoryCollection(new Dictionary<string, string>
                                                       {
                                                               { "ConnectionStrings:DefaultConnection", databaseContext.Main.ConnectionString }
                                                       }).Build();

            return new ServiceCollection()

                   .RegisterGeneralDependencyInjection(configuration)

                   .ApplyIntegrationTestServices()

                   .ReplaceSingleton<IIntegrationEventBus, IntegrationTestIntegrationEventBus>()
                   .ReplaceScoped<ICapTransactionManager, IntegrationTestCapTransactionManager>()

                   .AddSingleton<AttachmentsSampleSystemInitializer>()

                   .RegisterControllers(new[] { typeof(EmployeeController).Assembly })

                   .AddSingleton(databaseContext)
                   .AddSingleton<DataHelper>()
                   .AddSingleton<AuthHelper>()
                   .AddSingleton(configUtil)
                   .ValidateDuplicateDeclaration()
                   .BuildServiceProvider(new ServiceProviderOptions { ValidateOnBuild = true, ValidateScopes = true });
        }
    }
}
