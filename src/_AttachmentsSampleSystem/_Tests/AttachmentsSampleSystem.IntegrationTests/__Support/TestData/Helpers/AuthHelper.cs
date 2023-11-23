using System;

using Automation.ServiceEnvironment;
using Automation.Utils;

using Framework.Attachments.BLL;
using Framework.Authorization.BLL;
using Framework.Authorization.Domain;
using Framework.DomainDriven;
using Framework.DomainDriven.BLL;
using Framework.SecuritySystem;

using Microsoft.Extensions.DependencyInjection;

namespace AttachmentsSampleSystem.IntegrationTests.__Support.TestData.Helpers
{
    public class AuthHelper : AuthHelperBase<IAttachmentsBLLContext>
    {
        public AuthHelper(IServiceProvider rootServiceProvider) : base(rootServiceProvider)
        {
        }


        public TestPermission CreateRole(string name, params SecurityOperation[] operations)
        {
            this.RootServiceProvider.GetRequiredService<IServiceEvaluator<IAuthorizationBLLContext>>().Evaluate(DBSessionMode.Write,
                ctx =>
                {
                    var role = ctx.Logics.BusinessRole.GetByNameOrCreate(name);

                    foreach (var operation in operations)
                    {
                        new BusinessRoleOperationLink(role)
                        {
                                Operation = ctx.Logics.Operation.GetByName(operation.Name)
                        };
                    }

                    ctx.Logics.BusinessRole.Save(role);
                });

            return new TestPermission(name);
        }
    }
}
