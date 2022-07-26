using System;

using Framework.Core;
using Framework.Validation;

using Framework.DomainDriven.BLL;

namespace AttachmentsSampleSystem.BLL;

public class AttachmentsSampleSystemValidatorCompileCache : ValidatorCompileCache
{
    public AttachmentsSampleSystemValidatorCompileCache(IAvailableValues availableValues) :
            base(availableValues
                 .ToBLLContextValidationExtendedData<IAttachmentsSampleSystemBLLContext, AttachmentsSampleSystem.Domain.PersistentDomainObjectBase, Guid>()
                 .Pipe(extendedValidationData => new AttachmentsSampleSystemValidationMap(extendedValidationData)))
    {
    }
}
