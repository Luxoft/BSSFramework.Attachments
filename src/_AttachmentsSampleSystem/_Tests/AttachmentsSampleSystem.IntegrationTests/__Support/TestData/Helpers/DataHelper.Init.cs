using System;

using AttachmentsSampleSystem.BLL;

using Automation.ServiceEnvironment;

using Microsoft.Extensions.DependencyInjection;

namespace AttachmentsSampleSystem.IntegrationTests.__Support.TestData.Helpers
{
    public partial class DataHelper : RootServiceProviderContainer<IAttachmentsSampleSystemBLLContext>
    {
        public DataHelper(IServiceProvider rootServiceProvider)
                : base(rootServiceProvider)
        {
        }

        public AuthHelper AuthHelper => this.RootServiceProvider.GetRequiredService<AuthHelper>();

        private Guid GetGuid(Guid? id)
        {
            id = id ?? Guid.NewGuid();
            return (Guid)id;
        }
    }
}
