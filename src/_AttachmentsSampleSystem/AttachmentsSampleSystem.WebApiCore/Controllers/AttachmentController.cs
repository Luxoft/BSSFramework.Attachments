using Framework.Attachments.BLL;
using Framework.DomainDriven.BLL;
using Framework.DomainDriven.ServiceModel.Service;
using Framework.Exceptions;

using JetBrains.Annotations;

namespace AttachmentsSampleSystem.WebApiCore.Controllers
{
    public class AttachmentController : Framework.Attachments.WebApi.AttachmentController
    {
        public AttachmentController([NotNull] IContextEvaluator<IAttachmentsBLLContext> contextEvaluator) : base(contextEvaluator)
        {
        }
    }
}
