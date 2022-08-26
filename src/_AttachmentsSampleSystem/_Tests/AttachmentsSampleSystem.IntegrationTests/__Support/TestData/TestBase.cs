using Automation.ServiceEnvironment;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using AttachmentsSampleSystem.BLL;
using AttachmentsSampleSystem.IntegrationTests.__Support.TestData.Helpers;
using AttachmentsSampleSystem.WebApiCore.Controllers;

namespace AttachmentsSampleSystem.IntegrationTests.__Support.TestData
{
    [TestClass]
    public class TestBase : IntegrationTestBase<IAttachmentsSampleSystemBLLContext>
    {
        protected TestBase()
                : base(AttachmentsSampleSystemTestEnvironment.Current.ServiceProviderPool)
        {
            // Workaround for System.Drawing.Common problem https://chowdera.com/2021/12/202112240234238356.html
            System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
        }

        protected DataHelper DataHelper => this.RootServiceProvider.GetService<DataHelper>();

        protected AuthHelper AuthHelper => this.RootServiceProvider.GetService<AuthHelper>();

        [TestInitialize]
        public void TestBaseInitialize()
        {
            base.Initialize();
        }

        [TestCleanup]
        public void BaseTestCleanup()
        {
            base.Cleanup();
        }

        protected ControllerEvaluator<AuthSLJsonController> GetAuthControllerEvaluator(string principalName = null)
        {
            return this.GetControllerEvaluator<AuthSLJsonController>(principalName);
        }

        protected ControllerEvaluator<ConfigSLJsonController> GetConfigurationControllerEvaluator(string principalName = null)
        {
            return this.GetControllerEvaluator<ConfigSLJsonController>(principalName);
        }
    }
}
