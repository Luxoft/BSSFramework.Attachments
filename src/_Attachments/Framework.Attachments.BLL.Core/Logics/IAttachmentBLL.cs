using System;
using System.Collections.Generic;

using Framework.Attachments.Domain;
using Framework.Persistent;



namespace Framework.Attachments.BLL
{
    public partial interface IAttachmentBLL
    {
        IList<Attachment> GetObjectsBy(Type type, Guid domainObjectId);

        IList<Attachment> GetObjectsBy<TDomainObject>(TDomainObject domainObject)
            where TDomainObject : IIdentityObject<Guid>;
    }
}
