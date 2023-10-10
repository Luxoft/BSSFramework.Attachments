using Framework.SecuritySystem;

namespace Framework.Attachments.BLL;

public record AttachmentDomainObjectSecurityOperationInfo<TDomainObject>(
        SecurityOperation? ViewOperation,
        SecurityOperation? EditOperation)
        : DomainObjectSecurityOperationInfo(typeof(TDomainObject), ViewOperation, EditOperation);
