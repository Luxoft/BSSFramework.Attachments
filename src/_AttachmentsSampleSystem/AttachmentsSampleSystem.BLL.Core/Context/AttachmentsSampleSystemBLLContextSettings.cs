using Framework.Core;

using AttachmentsSampleSystem.Domain;

namespace AttachmentsSampleSystem.BLL;

public class AttachmentsSampleSystemBLLContextSettings : IAttachmentsSampleSystemBLLContextSettings
{
    public ITypeResolver<string> TypeResolver { get; init; } = TypeSource.FromSample<PersistentDomainObjectBase>().ToDefaultTypeResolver();
}
