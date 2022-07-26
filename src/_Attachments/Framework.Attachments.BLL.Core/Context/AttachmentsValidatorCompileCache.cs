using System;

using Framework.Core;
using Framework.Validation;

using Framework.DomainDriven.BLL;

namespace Framework.Attachments.BLL;

public class AttachmentsValidatorCompileCache : ValidatorCompileCache
{
    public AttachmentsValidatorCompileCache(IAvailableValues availableValues) :
            base(availableValues
                 .ToBLLContextValidationExtendedData<IAttachmentsBLLContext, Attachments.Domain.PersistentDomainObjectBase, Guid>()
                 .Pipe(extendedValidationData => new AttachmentsValidationMap(extendedValidationData)))
    {
    }
}
