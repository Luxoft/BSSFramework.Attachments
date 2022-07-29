using System.Collections.Generic;
using System.Linq;

using Framework.Configuration.BLL;
using Framework.Core;
using Framework.DomainDriven.BLL;
using Framework.DomainDriven.ServiceModel.IAD;
using Framework.Attachments.BLL;

namespace Framework.Attachments.Environment;

public class AttachmentsDBSessionEventListener : IDBSessionEventListener
{
    private readonly IInitializeManager initializeManager;

    private readonly IAttachmentsBLLContext attachmentsBllContext;

    public AttachmentsDBSessionEventListener(
            IInitializeManager initializeManager,
            IAttachmentsBLLContext attachmentsBllContext)
    {
        this.initializeManager = initializeManager;
        this.attachmentsBllContext = attachmentsBllContext;
    }

    public void OnFlushed(DALChangesEventArgs eventArgs)
    {
    }

    public void OnBeforeTransactionCompleted(DALChangesEventArgs eventArgs)
    {
        if (this.initializeManager.IsInitialize)
        {
            return;
        }

        this.GetAttachmentCleanerDALListeners().Foreach(listener => listener.Process(eventArgs));
    }

    public void OnAfterTransactionCompleted(DALChangesEventArgs eventArgs)
    {
    }

    private IEnumerable<IBeforeTransactionCompletedDALListener> GetAttachmentCleanerDALListeners()
    {
        return from targetSystemService in this.attachmentsBllContext.GetPersistentTargetSystemServices()

               where targetSystemService.HasAttachments

               select new AttachmentCleanerDALListener(targetSystemService);
    }
}
