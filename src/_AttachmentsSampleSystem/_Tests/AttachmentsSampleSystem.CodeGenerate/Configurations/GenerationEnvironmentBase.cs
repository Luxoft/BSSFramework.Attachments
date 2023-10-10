using System;

using Framework.DomainDriven.Generation.Domain;

using AttachmentsSampleSystem.Domain;

namespace AttachmentsSampleSystem.CodeGenerate
{
    public abstract class GenerationEnvironmentBase : GenerationEnvironment<DomainObjectBase, PersistentDomainObjectBase, AuditPersistentDomainObjectBase, Guid>
    {

        protected GenerationEnvironmentBase()
            : base(v => v.Id)
        {
        }


        public override Type SecurityOperationType { get; } = typeof(AttachmentsSampleSystemSecurityOperation);

        public override Type OperationContextType { get; } = typeof(AttachmentsSampleSystemOperationContext);
    }
}
