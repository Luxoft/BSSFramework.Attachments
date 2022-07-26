using Framework.Core.Services;
using Framework.DomainDriven.NHibernate.Audit;

using Microsoft.AspNetCore.Http;

namespace AttachmentsSampleSystem.WebApiCore.Env
{
    public class AttachmentsSampleSystemDefaultUserAuthenticationService : DomainDefaultUserAuthenticationService, IAuditRevisionUserAuthenticationService
    {

        private readonly IHttpContextAccessor httpContextAccessor;

        public AttachmentsSampleSystemDefaultUserAuthenticationService(IHttpContextAccessor httpContextAccessor) => this.httpContextAccessor = httpContextAccessor;

        public override string GetUserName() => this.httpContextAccessor.HttpContext?.User?.Identity?.Name ?? base.GetUserName();
    }
}
