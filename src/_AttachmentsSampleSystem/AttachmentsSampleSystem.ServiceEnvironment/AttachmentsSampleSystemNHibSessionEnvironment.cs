#nullable enable

using System.Collections.Generic;
using System.Data;

using Framework.Cap.Abstractions;
using Framework.DomainDriven.DALExceptions;
using Framework.DomainDriven.NHibernate;
using Framework.DomainDriven.NHibernate.Audit;

namespace AttachmentsSampleSystem.ServiceEnvironment;

public class AttachmentsSampleSystemNHibSessionEnvironment : NHibSessionEnvironment
{
    private readonly ICapTransactionManager manager;

    public AttachmentsSampleSystemNHibSessionEnvironment(
            NHibConnectionSettings connectionSettings,
            IEnumerable<IMappingSettings> mappingSettings,
            IAuditRevisionUserAuthenticationService auditRevisionUserAuthenticationService,
            ICapTransactionManager manager,
            INHibSessionEnvironmentSettings settings,
            IDalValidationIdentitySource dalValidationIdentitySource)
            : base(connectionSettings, mappingSettings, auditRevisionUserAuthenticationService, settings, dalValidationIdentitySource) =>
            this.manager = manager;

    public override void ProcessTransaction(IDbTransaction dbTransaction)
    {
        base.ProcessTransaction(dbTransaction);
        this.manager.Enlist(dbTransaction);
    }
}
