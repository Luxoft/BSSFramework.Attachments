using System;
using System.Collections.Generic;

using AttachmentsSampleSystem.DbGenerate;
using AttachmentsSampleSystem.IntegrationTests.__Support;
using AttachmentsSampleSystem.IntegrationTests.__Support.TestData;

using Automation.Utils;
using Automation.Utils.DatabaseUtils;
using Automation.Utils.DatabaseUtils.Interfaces;
using Framework.DomainDriven.DBGenerator;

namespace AttachmentsSampleSystem.IntegrationTests.Support.Utils
{
    public class AttachmentsSampleSystemTestDatabaseGenerator : TestDatabaseGenerator
    {
        protected override IEnumerable<string> TestServers => new List<string> { "." };

        private readonly IServiceProvider ServiceProvider;

        public AttachmentsSampleSystemTestDatabaseGenerator(IDatabaseContext databaseContext, ConfigUtil configUtil, IServiceProvider serviceProvider)
            : base(databaseContext, configUtil)
        {
            this.ServiceProvider = serviceProvider;
        }

        public override void GenerateDatabases()
        {
            new DbGeneratorTest().GenerateAllDB(
                this.DatabaseContext.Main.DataSource,
                mainDatabaseName: this.DatabaseContext.Main.DatabaseName,
                credential: UserCredential.Create(
                    this.DatabaseContext.Main.UserId,
                    this.DatabaseContext.Main.Password));
        }

        public override void CheckTestDatabase()
        {
            if (this.DatabaseContext.Server.TableRowCount(this.DatabaseContext.Main.DatabaseName, "Location") > 100)
            {
                throw new Exception(
                    "Location row count more than 100. Please ensure that you run tests in Test Environment. If you want to run tests in the environment, please delete all Location rows (Location table) manually and rerun tests.");
            }
        }

        public override void GenerateTestData() => new TestDataInitialize(this.ServiceProvider).TestData();

        public override void ExecuteInsertsForDatabases()
        {
            base.ExecuteInsertsForDatabases();

            CoreDatabaseUtil.ExecuteSqlFromFolder(this.DatabaseContext.Main.ConnectionString, @"__Support/Scripts/Authorization", this.DatabaseContext.Main.DatabaseName);
            CoreDatabaseUtil.ExecuteSqlFromFolder(this.DatabaseContext.Main.ConnectionString,@"__Support/Scripts/Configuration", this.DatabaseContext.Main.DatabaseName);
            CoreDatabaseUtil.ExecuteSqlFromFolder(this.DatabaseContext.Main.ConnectionString, @"__Support/Scripts/Attachments", this.DatabaseContext.Main.DatabaseName);
            CoreDatabaseUtil.ExecuteSqlFromFolder(this.DatabaseContext.Main.ConnectionString, @"__Support/Scripts/AttachmentsSampleSystem", this.DatabaseContext.Main.DatabaseName);

            new BssFluentMigrator(this.DatabaseContext.Main.ConnectionString, typeof(InitNumberInDomainObjectEventMigration).Assembly).Migrate();
        }
    }
}
