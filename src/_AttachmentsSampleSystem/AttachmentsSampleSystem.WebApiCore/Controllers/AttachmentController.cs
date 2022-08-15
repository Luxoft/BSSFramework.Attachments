using Framework.Attachments.BLL;
using Framework.DomainDriven;

using JetBrains.Annotations;

namespace AttachmentsSampleSystem.WebApiCore.Controllers
{
    public class AttachmentController : Framework.Attachments.WebApi.AttachmentController
    {
        public AttachmentController([NotNull] IContextEvaluator<IAttachmentsBLLContext> contextEvaluator)
                : base(contextEvaluator)
        {
        }
    }
}
