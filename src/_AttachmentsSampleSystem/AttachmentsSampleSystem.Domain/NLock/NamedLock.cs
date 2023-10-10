using Framework.DomainDriven.BLL;
using Framework.DomainDriven.Lock;

namespace AttachmentsSampleSystem.Domain
{
    [BLLRole]
    public class NamedLock : AuditPersistentDomainObjectBase, INamedLock<NamedLockOperation>
    {
        private NamedLockOperation lockOperation;

        public NamedLock()
        {

        }

        public virtual NamedLockOperation LockOperation
        {
            get { return this.lockOperation; }
            set { this.lockOperation = value; }
        }
    }
}
