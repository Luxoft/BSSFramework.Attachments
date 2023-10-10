using Framework.Attachments.BLL;
using Framework.DomainDriven;



namespace AttachmentsSampleSystem.WebApiCore.Controllers
{
    public class AttachmentController : Framework.Attachments.WebApi.AttachmentController
    {
        public AttachmentController(IContextEvaluator<IAttachmentsBLLContext> contextEvaluator)
                : base(contextEvaluator)
        {
        }
    }
}
