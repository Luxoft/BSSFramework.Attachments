using System;
using System.Collections.Generic;

using Framework.Attachments.Domain;
using Framework.Persistent;



namespace Framework.Attachments.BLL
{
    public partial interface IAttachmentContainerBLL
    {
        IList<AttachmentContainer> GetNotSynchronizated();

        AttachmentContainer GetObjectBy(Type type, Guid domainObjectId);

        AttachmentContainer GetObjectBy<TDomainObject>(TDomainObject domainObject)
            where TDomainObject : class, IIdentityObject<Guid>;
    }
}
