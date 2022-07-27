using System;
using System.Linq;

using Framework.Attachments.BLL;
using Framework.Core;
using Framework.DomainDriven.BLL;

using JetBrains.Annotations;

namespace Framework.Attachments.Environment
{
    public class AttachmentCleanerDALListener : IBeforeTransactionCompletedDALListener
    {
        private readonly ITargetSystemService targetSystemService;


        public AttachmentCleanerDALListener([NotNull] ITargetSystemService targetSystemService)
        {
            this.targetSystemService = targetSystemService ?? throw new ArgumentNullException(nameof(targetSystemService));
        }


        public void Process(DALChangesEventArgs eventArgs)
        {
            if (eventArgs == null) throw new ArgumentNullException(nameof(eventArgs));

            if (eventArgs.Changes.RemovedItems.Any())
            {
                foreach (var pair in eventArgs.Changes.GroupByType().Where(pair => this.targetSystemService.IsAssignable(pair.Key)))
                {
                    var removeObjects = pair.Value.RemovedItems.ToArray(pair.Key);

                    this.targetSystemService.TryRemoveAttachments(removeObjects);
                }
            }
        }
    }
}
