using System;

namespace AttachmentsSampleSystem.IntegrationTests.__Support.ServiceEnvironment;

public interface IRootServiceProviderContainer
{
    IServiceProvider RootServiceProvider { get; }
}
