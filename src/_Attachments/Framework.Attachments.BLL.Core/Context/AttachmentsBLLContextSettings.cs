using System;

using Framework.Core;

using Framework.Attachments.Domain;

namespace Framework.Attachments.BLL;

public class AttachmentsBLLContextSettings : IAttachmentsBLLContextSettings
{
    public ITypeResolver<string> TypeResolver { get; init; } = TypeSource.FromSample<PersistentDomainObjectBase>().ToDefaultTypeResolver();
}
