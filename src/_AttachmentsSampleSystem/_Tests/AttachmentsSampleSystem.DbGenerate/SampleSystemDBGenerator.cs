﻿using System.Linq;

using Framework.DomainDriven.DBGenerator;
using Framework.DomainDriven.Metadata;
using Framework.DomainDriven.NHibernate;
using Framework.Persistent.Mapping;

namespace AttachmentsSampleSystem.DbGenerate
{
    public class AttachmentsSampleSystemDBGenerator : DBGenerator
    {
        public AttachmentsSampleSystemDBGenerator(IMappingSettings settings) : base(settings)
        {
        }

        protected override void FilterMetadata(AssemblyMetadata metadata)
        {
            base.FilterMetadata(metadata);

            var nextDomainTypes = metadata.DomainTypes.Where(this.Used).ToList();

            metadata.DomainTypes = nextDomainTypes;
        }

        private bool Used(DomainTypeMetadata domainTypeMetadata)
        {
            var tableAttribute = domainTypeMetadata.DomainType.GetTableAttribute();

            return tableAttribute == null || tableAttribute.Schema == "app";
        }
    }
}
