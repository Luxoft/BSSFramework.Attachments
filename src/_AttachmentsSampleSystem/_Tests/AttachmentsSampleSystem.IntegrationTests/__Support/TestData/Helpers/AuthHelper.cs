using System;

using Automation.ServiceEnvironment;

using Framework.Attachments.BLL;

namespace AttachmentsSampleSystem.IntegrationTests.__Support.TestData.Helpers
{
    public class AuthHelper : AuthHelperBase<IAttachmentsBLLContext>
    {
        public AuthHelper(IServiceProvider rootServiceProvider) : base(rootServiceProvider)
        {
        }
    }
}
