using Framework.Attachments.BLL;
using Framework.DomainDriven;



namespace AttachmentsSampleSystem.WebApiCore.Controllers
{
    public class AttachmentController : Framework.Attachments.WebApi.AttachmentController
    {
        public AttachmentController(IServiceEvaluator<IAttachmentsBLLContext> contextEvaluator)
                : base(contextEvaluator)
        {
        }
    }
}
