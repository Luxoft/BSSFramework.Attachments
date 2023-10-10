using Framework.DomainDriven.Lock;

namespace AttachmentsSampleSystem.Domain
{
    public enum NamedLockOperation
    {
        [GlobalLock(typeof(BusinessUnitAncestorLink))]
        BusinessUnitAncestorLock,
    }
}
