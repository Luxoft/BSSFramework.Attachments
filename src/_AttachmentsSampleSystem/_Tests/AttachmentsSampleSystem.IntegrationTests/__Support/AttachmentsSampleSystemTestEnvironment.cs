using System;

using Automation;
using Automation.Utils.DatabaseUtils;
using Automation.Utils.DatabaseUtils.Interfaces;

using AttachmentsSampleSystem.IntegrationTests.__Support;
using AttachmentsSampleSystem.IntegrationTests.Support.Utils;

namespace AttachmentsSampleSystem.IntegrationTests;

public class AttachmentsSampleSystemTestEnvironment : TestEnvironment
{
    private AttachmentsSampleSystemTestEnvironment()
    {
    }

    protected override string EnvironmentPrefix => $"{nameof(AttachmentsSampleSystem)}_";

    protected override ServiceProviderPool BuildServiceProvidePool()
    {
        return new AttachmentsSampleSystemServiceProviderPool(this.RootConfiguration, this.ConfigUtil);
    }

    protected override TestDatabaseGenerator GetDatabaseGenerator(IServiceProvider serviceProvider, IDatabaseContext databaseContext)
    {
        return new AttachmentsSampleSystemTestDatabaseGenerator(databaseContext, this.ConfigUtil ,serviceProvider);
    }

    public static readonly AttachmentsSampleSystemTestEnvironment Current = new();
}
