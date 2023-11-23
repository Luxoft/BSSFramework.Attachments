using AttachmentsSampleSystem.Domain;

using Automation.Utils;
using AttachmentsSampleSystem.Generated.DTO;

using Framework.Authorization.SecuritySystem;

namespace AttachmentsSampleSystem.IntegrationTests.__Support.TestData
{
    public class AttachmentsSampleSystemTestPermission : TestPermission
    {
        public AttachmentsSampleSystemTestPermission(
                string securityRoleName,
                BusinessUnitIdentityDTO? businessUnit,
                LocationIdentityDTO? location = null)
                : base(securityRoleName)
        {
            this.BusinessUnit = businessUnit;
            this.Location = location;
        }

        public AttachmentsSampleSystemTestPermission(
                SecurityRole securityRole,
                BusinessUnitIdentityDTO? businessUnit,
                LocationIdentityDTO? location = null)
                : base(securityRole)
        {
            this.BusinessUnit = businessUnit;
            this.Location = location;
        }

        public BusinessUnitIdentityDTO? BusinessUnit
        {
            get => this.GetSingleIdentity(typeof(BusinessUnit), v => new BusinessUnitIdentityDTO(v));
            set => this.SetSingleIdentity(typeof(BusinessUnit), v => v.Id, value);
        }

        public LocationIdentityDTO? Location
        {
            get => this.GetSingleIdentity(typeof(Location), v => new LocationIdentityDTO(v));
            set => this.SetSingleIdentity(typeof(Location), v => v.Id, value);
        }
    }
}
