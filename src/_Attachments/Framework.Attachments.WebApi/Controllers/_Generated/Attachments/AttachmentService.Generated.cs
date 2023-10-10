namespace Framework.Attachments.WebApi
{
    using Framework.Attachments.Generated.DTO;


    [Microsoft.AspNetCore.Mvc.ApiControllerAttribute()]
    [Microsoft.AspNetCore.Mvc.ApiVersionAttribute("1.0")]
    [Microsoft.AspNetCore.Mvc.RouteAttribute("AttachmentsApi/v{version:apiVersion}/[controller]")]
    public partial class AttachmentController : Framework.DomainDriven.WebApiNetCore.ApiControllerBase<Framework.Attachments.BLL.IAttachmentsBLLContext, Framework.DomainDriven.ServiceModel.Service.EvaluatedData<Framework.Attachments.BLL.IAttachmentsBLLContext, Framework.Attachments.Generated.DTO.IAttachmentsDTOMappingService>>
    {

        protected virtual void RemoveAttachmentInternal(Framework.Attachments.Generated.DTO.AttachmentIdentityDTO attachmentIdent, Framework.DomainDriven.ServiceModel.Service.EvaluatedData<Framework.Attachments.BLL.IAttachmentsBLLContext, Framework.Attachments.Generated.DTO.IAttachmentsDTOMappingService> evaluateData, Framework.Attachments.BLL.IAttachmentBLL bll)
        {
            Framework.Attachments.Domain.Attachment domainObject = bll.GetById(attachmentIdent.Id, true);
            bll.Remove(domainObject);
        }
    }
}
