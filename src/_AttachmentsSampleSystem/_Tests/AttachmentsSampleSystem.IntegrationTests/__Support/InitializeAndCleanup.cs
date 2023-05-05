using AttachmentsSampleSystem.IntegrationTests.__Support.TestData.Helpers;
using AttachmentsSampleSystem.IntegrationTests.Support.Utils;
using AttachmentsSampleSystem.ServiceEnvironment;
using AttachmentsSampleSystem.WebApiCore.Controllers.Main;

using Automation;
using Automation.ServiceEnvironment;
using Automation.ServiceEnvironment.Services;

using Framework.Cap.Abstractions;
using Framework.DependencyInjection;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AttachmentsSampleSystem.IntegrationTests.__Support
{
    [TestClass]
    public class InitializeAndCleanup
    {
        public static readonly TestEnvironment TestEnvironment = new TestEnvironmentBuilder()
                                                                 .WithDefaultConfiguration($"{nameof(AttachmentsSampleSystem)}_")
                                                                 .WithDatabaseGenerator<AttachmentsSampleSystemTestDatabaseGenerator>()
                                                                 .WithServiceProviderBuildFunc(GetServices)
                                                                 .Build();

        [AssemblyInitialize]
        public static void EnvironmentInitialize(TestContext testContext)
        {
            TestEnvironment.AssemblyInitializeAndCleanup.EnvironmentInitialize();
        }

        [AssemblyCleanup]
        public static void EnvironmentCleanup()
        {
            TestEnvironment.AssemblyInitializeAndCleanup.EnvironmentCleanup();
        }

        private static IServiceCollection GetServices(IConfiguration configuration, IServiceCollection services)
        {
            return services
                   .RegisterGeneralDependencyInjection(configuration)

                   .ApplyIntegrationTestServices()

                   .ReplaceSingleton<IIntegrationEventBus, IntegrationTestIntegrationEventBus>()
                   .ReplaceScoped<ICapTransactionManager, IntegrationTestCapTransactionManager>()

                   .AddSingleton<AttachmentsSampleSystemInitializer>()

                   .RegisterControllers(new[] { typeof(EmployeeController).Assembly })

                   .AddSingleton<DataHelper>()
                   .AddSingleton<AuthHelper>()
                   .ValidateDuplicateDeclaration();
        }
    }
}
