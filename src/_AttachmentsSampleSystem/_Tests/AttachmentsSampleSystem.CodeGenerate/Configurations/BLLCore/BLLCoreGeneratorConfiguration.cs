using System;

namespace AttachmentsSampleSystem.CodeGenerate
{
    public class BLLCoreGeneratorConfiguration : Framework.DomainDriven.BLLCoreGenerator.GeneratorConfigurationBase<ServerGenerationEnvironment>
    {
        public BLLCoreGeneratorConfiguration(ServerGenerationEnvironment environment)
            : base(environment)
        {
        }
    }
}
