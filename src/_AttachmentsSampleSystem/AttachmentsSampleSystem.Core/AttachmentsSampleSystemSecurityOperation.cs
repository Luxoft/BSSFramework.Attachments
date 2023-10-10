using System;

using Framework.HierarchicalExpand;
using Framework.SecuritySystem;

namespace AttachmentsSampleSystem
{
    public static class AttachmentsSampleSystemSecurityOperation
    {
        public static DisabledSecurityOperation Disabled { get; } = SecurityOperation.Disabled;

        public static SecurityOperation<Guid> EmployeeView { get; } = new(nameof(EmployeeView), new Guid("c73dd1f6-74d5-4445-a265-2e96832a7f89")) { Description = "Employee View" };

        public static SecurityOperation<Guid> EmployeeEdit { get; } = new(nameof(EmployeeEdit), new Guid("45e8e5b8-620c-42c6-baf5-20ab1cf27b8e")) { Description = "Employee Edit" };

        public static SecurityOperation<Guid> BusinessUnitView { get; } = new(nameof(BusinessUnitView), new Guid("b79e7132-845e-4bbf-8c3a-8fa3f6b31cf6")) { Description = "Business Unit View", ExpandType = HierarchicalExpandType.All };

        public static SecurityOperation<Guid> BusinessUnitEdit { get; } = new(nameof(BusinessUnitEdit), new Guid("10000000-71c4-47cd-8683-000000000003")) { Description = "Business Unit Edit" };

        public static SecurityOperation<Guid> HRDepartmentView { get; } = new(nameof(HRDepartmentView), new Guid("00000000-71c4-47cd-8683-000000000001"));

        public static SecurityOperation<Guid> HRDepartmentEdit { get; } = new(nameof(HRDepartmentEdit), new Guid("00000000-71c4-47cd-8683-000000000002"));

        public static SecurityOperation<Guid> LocationView { get; } = new(nameof(LocationView), new Guid("e5377866-ff6d-4d05-912f-2d3c72f27fa7"));

        public static SecurityOperation<Guid> LocationEdit { get; } = new(nameof(LocationEdit), new Guid("034c4e00-9c62-422b-98b8-b119c1991596"));

        public static SecurityOperation<Guid> LocationViewAttachment { get; } = new(nameof(LocationViewAttachment), new Guid("ee105b0e-e0d0-4e48-8eab-ca1db0abbdb7"));

        public static SecurityOperation<Guid> LocationEditAttachment { get; } = new(nameof(LocationEditAttachment), new Guid("29d353f0-1729-47ee-9563-26f39366d8e2"));
    }
}
