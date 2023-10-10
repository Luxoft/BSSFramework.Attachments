using Framework.DomainDriven.BLLCoreGenerator;

namespace Framework.Attachments.TestGenerate
{
    public class BLLCoreGeneratorConfiguration : GeneratorConfigurationBase<ServerGenerationEnvironment>
    {
        public BLLCoreGeneratorConfiguration(ServerGenerationEnvironment environment)
            : base(environment)
        {
        }

        public override bool GenerateAuthServices { get; } = false;
    }
}
