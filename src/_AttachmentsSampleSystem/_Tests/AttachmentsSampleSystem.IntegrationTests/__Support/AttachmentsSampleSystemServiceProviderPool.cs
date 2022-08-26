using System;

using Automation;
using Automation.Utils;
using Automation.Utils.DatabaseUtils.Interfaces;

using Microsoft.Extensions.Configuration;

namespace AttachmentsSampleSystem.IntegrationTests.__Support;

public class AttachmentsSampleSystemServiceProviderPool : ServiceProviderPool
{
    public AttachmentsSampleSystemServiceProviderPool(IConfiguration rootRootConfiguration, ConfigUtil configUtil) : base(rootRootConfiguration, configUtil)
    {
    }

    protected override IServiceProvider Build(IDatabaseContext databaseContext)
    {
        return AttachmentsSampleSystemTestRootServiceProvider.Create(this.RootConfiguration, databaseContext, this.ConfigUtil);
    }
}
