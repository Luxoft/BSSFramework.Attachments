using System;

using Automation.Utils;

using AttachmentsSampleSystem.Generated.DTO;
using AttachmentsSampleSystem.IntegrationTests.__Support.ServiceEnvironment;

using BusinessRole = AttachmentsSampleSystem.IntegrationTests.__Support.Utils.BusinessRole;

namespace AttachmentsSampleSystem.IntegrationTests.__Support.TestData.Helpers
{
    public class AuthHelper : Utils.Framework.Authorization, IRootServiceProviderContainer
    {
        public AuthHelper(IServiceProvider rootServiceProvider)
                : base(rootServiceProvider)
        {
        }

        public void SetUserRole(EmployeeIdentityDTO employee, params IPermissionDefinition[] permissions)
        {
            var login = this.EvaluateRead(context => context.Logics.Employee.GetById(employee.Id).Login);
            this.SetUserRole(login, permissions);
        }

        public void SetCurrentUserRole(BusinessRole businessRole)
        {
            this.SetCurrentUserRole(new AttachmentsSampleSystemPermission(businessRole));
        }


        public string GetCurrentUserLogin()
        {
            return this.EvaluateRead(context => context.Authorization.CurrentPrincipalName);
        }
    }
}
