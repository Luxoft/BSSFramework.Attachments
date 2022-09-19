using Framework.Validation;

using Microsoft.Extensions.DependencyInjection;

namespace AttachmentsSampleSystem.BLL;

public partial class AttachmentsSampleSystemValidator : IAttachmentsSampleSystemValidator
{
    [ActivatorUtilitiesConstructor]
    public AttachmentsSampleSystemValidator(IAttachmentsSampleSystemBLLContext context, AttachmentsSampleSystemValidatorCompileCache cache) :
            this(context, (ValidatorCompileCache)cache)
    {
    }
}
