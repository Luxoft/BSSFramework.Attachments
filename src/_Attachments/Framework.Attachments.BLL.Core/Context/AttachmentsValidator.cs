using Framework.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Attachments.BLL;

public partial class AttachmentsValidator : IAttachmentsValidator
{
    [ActivatorUtilitiesConstructor]
    public AttachmentsValidator(IAttachmentsBLLContext context, AttachmentsValidatorCompileCache cache) :
            this(context, (ValidatorCompileCache)cache)
    {
    }
}
