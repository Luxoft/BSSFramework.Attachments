using System.Reflection;

using Framework.DomainDriven.WebApiNetCore;

namespace AttachmentsSampleSystem.IntegrationTests.__Support.ServiceEnvironment;

public class IntegrationTestsWebApiCurrentMethodResolver : IWebApiCurrentMethodResolver
{
    private MethodInfo currentMethod;

    public MethodInfo GetCurrentMethod()
    {
        return this.currentMethod;
    }

    public void SetCurrentMethod(MethodInfo methodInfo)
    {
        this.currentMethod = methodInfo;
    }
}
