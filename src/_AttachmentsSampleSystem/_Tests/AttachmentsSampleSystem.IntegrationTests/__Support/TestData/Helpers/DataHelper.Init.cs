using System;

using AttachmentsSampleSystem.BLL;
using AttachmentsSampleSystem.Generated.DTO;
using AttachmentsSampleSystem.IntegrationTests.__Support.ServiceEnvironment;

namespace AttachmentsSampleSystem.IntegrationTests.__Support.TestData.Helpers
{
    public partial class DataHelper : IRootServiceProviderContainer
    {
        public DataHelper(IServiceProvider rootServiceProvider)
        {
            this.RootServiceProvider = rootServiceProvider;
        }

        public IServiceProvider RootServiceProvider { get; }


        public AuthHelper AuthHelper { private get; set; }

        public AttachmentsSampleSystemServerPrimitiveDTOMappingService GetMappingService(IAttachmentsSampleSystemBLLContext context)
        {
            return new AttachmentsSampleSystemServerPrimitiveDTOMappingService(context);
        }

        private Guid GetGuid(Guid? id)
        {
            id = id ?? Guid.NewGuid();
            return (Guid)id;
        }
    }
}
