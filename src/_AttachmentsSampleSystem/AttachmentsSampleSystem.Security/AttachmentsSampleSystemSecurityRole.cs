using System;

using Framework.Authorization;
using Framework.Authorization.SecuritySystem;
using Framework.Configuration;
using Framework.SecuritySystem.Bss;

namespace AttachmentsSampleSystem.Security;

public static class AttachmentsSampleSystemSecurityRole
{
    public static SecurityRole Administrator { get; } = SecurityRole.CreateAdministrator(
        new Guid("d9c1d2f0-0c2f-49ab-bb0b-de13a456169e"),
        new[] { typeof(AuthorizationSecurityOperation), typeof(ConfigurationSecurityOperation), typeof(AttachmentsSampleSystemSecurityOperation) });

    public static SecurityRole SystemIntegration { get; } = new SecurityRole(
        new Guid("df74d544-5945-4380-944e-a3a9001252be"),
        nameof(SystemIntegration),
        BssSecurityOperation.SystemIntegration,
        ConfigurationSecurityOperation.ProcessModifications,
        ConfigurationSecurityOperation.QueueMonitoring);
}
