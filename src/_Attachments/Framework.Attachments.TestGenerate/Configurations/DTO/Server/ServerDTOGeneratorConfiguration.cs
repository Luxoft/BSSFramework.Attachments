using System;

using Framework.DomainDriven.DTOGenerator;
using Framework.DomainDriven.DTOGenerator.Server;

namespace Framework.Attachments.TestGenerate
{
    public class ServerDTOGeneratorConfiguration : ServerGeneratorConfigurationBase<ServerGenerationEnvironment>
    {
        public ServerDTOGeneratorConfiguration(ServerGenerationEnvironment environment)
            : base(environment)
        {
        }

        public override string DataContractNamespace => this.Environment.DTODataContractNamespace;

        public override bool ForceGenerateProperties(Type domainType, DTOFileType fileType)
        {
            return true;
        }
    }
}
