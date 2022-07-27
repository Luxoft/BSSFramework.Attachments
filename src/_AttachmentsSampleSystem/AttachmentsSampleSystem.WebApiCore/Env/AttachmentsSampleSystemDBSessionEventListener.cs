using System.Collections.Generic;
using System.Linq;

using Framework.Configuration.BLL;
using Framework.Core;
using Framework.DomainDriven.BLL;
using Framework.DomainDriven.ServiceModel.IAD;
using Framework.Attachments.BLL;
using Framework.Attachments.Environment;

namespace AttachmentsSampleSystem.WebApiCore;

public class AttachmentsSampleSystemDBSessionEventListener : DBSessionEventListener, IDBSessionEventListener
{
    private readonly IInitializeManager initializeManager;

    private readonly IAttachmentsBLLContext attachmentsBllContext;

    public AttachmentsSampleSystemDBSessionEventListener(
            IInitializeManager initializeManager,
            IEnumerable<IFlushedDALListener> flushedDalListener,
            IEnumerable<IBeforeTransactionCompletedDALListener> beforeTransactionCompletedDalListener,
            IEnumerable<IAfterTransactionCompletedDALListener> afterTransactionCompletedDalListener,
            IConfigurationBLLContext configurationBLLContext,
            IAttachmentsBLLContext attachmentsBllContext,
            IStandardSubscriptionService subscriptionService)
            : base(initializeManager, flushedDalListener, beforeTransactionCompletedDalListener, afterTransactionCompletedDalListener, configurationBLLContext, subscriptionService)
    {
        this.initializeManager = initializeManager;
        this.attachmentsBllContext = attachmentsBllContext;
    }

    public new void OnBeforeTransactionCompleted(DALChangesEventArgs eventArgs)
    {
        if (this.initializeManager.IsInitialize)
        {
            return;
        }

        base.OnBeforeTransactionCompleted(eventArgs);

        this.GetAttachmentCleanerDALListeners().Foreach(listener => listener.Process(eventArgs));
    }

    private IEnumerable<IBeforeTransactionCompletedDALListener> GetAttachmentCleanerDALListeners()
    {
        return from targetSystemService in this.attachmentsBllContext.GetPersistentTargetSystemServices()

               where targetSystemService.HasAttachments

               select new AttachmentCleanerDALListener(targetSystemService);
    }
}
