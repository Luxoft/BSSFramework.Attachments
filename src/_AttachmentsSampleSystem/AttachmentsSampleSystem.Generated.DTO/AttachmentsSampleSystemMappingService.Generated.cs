﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AttachmentsSampleSystem.Generated.DTO
{
    
    
    public partial interface IAttachmentsSampleSystemDTOMappingService : Framework.DomainDriven.IDTOMappingService<AttachmentsSampleSystem.Domain.PersistentDomainObjectBase, System.Guid>
    {
        
        void MapAuditPersistentDomainObjectBase(AttachmentsSampleSystem.Domain.AuditPersistentDomainObjectBase domainObject, AttachmentsSampleSystem.Generated.DTO.BaseAuditPersistentDTO mappingObject);
        
        void MapBusinessUnit(AttachmentsSampleSystem.Domain.BusinessUnit domainObject, AttachmentsSampleSystem.Generated.DTO.BusinessUnitVisualDTO mappingObject);
        
        void MapBusinessUnit(AttachmentsSampleSystem.Domain.BusinessUnit domainObject, AttachmentsSampleSystem.Generated.DTO.BusinessUnitSimpleDTO mappingObject);
        
        void MapBusinessUnit(AttachmentsSampleSystem.Domain.BusinessUnit domainObject, AttachmentsSampleSystem.Generated.DTO.BusinessUnitFullDTO mappingObject);
        
        void MapBusinessUnit(AttachmentsSampleSystem.Domain.BusinessUnit domainObject, AttachmentsSampleSystem.Generated.DTO.BusinessUnitRichDTO mappingObject);
        
        void MapBusinessUnit(AttachmentsSampleSystem.Generated.DTO.BusinessUnitStrictDTO mappingObject, AttachmentsSampleSystem.Domain.BusinessUnit domainObject);
        
        void MapDomainObjectBase(AttachmentsSampleSystem.Domain.DomainObjectBase domainObject, AttachmentsSampleSystem.Generated.DTO.BaseAbstractDTO mappingObject);
        
        void MapEmployee(AttachmentsSampleSystem.Domain.Employee domainObject, AttachmentsSampleSystem.Generated.DTO.EmployeeSimpleDTO mappingObject);
        
        void MapEmployee(AttachmentsSampleSystem.Domain.Employee domainObject, AttachmentsSampleSystem.Generated.DTO.EmployeeFullDTO mappingObject);
        
        void MapEmployee(AttachmentsSampleSystem.Generated.DTO.EmployeeStrictDTO mappingObject, AttachmentsSampleSystem.Domain.Employee domainObject);
        
        void MapEmployee(AttachmentsSampleSystem.Generated.DTO.EmployeeUpdateDTO mappingObject, AttachmentsSampleSystem.Domain.Employee domainObject);
        
        void MapHRDepartment(AttachmentsSampleSystem.Domain.HRDepartment domainObject, AttachmentsSampleSystem.Generated.DTO.HRDepartmentVisualDTO mappingObject);
        
        void MapHRDepartment(AttachmentsSampleSystem.Domain.HRDepartment domainObject, AttachmentsSampleSystem.Generated.DTO.HRDepartmentSimpleDTO mappingObject);
        
        void MapHRDepartment(AttachmentsSampleSystem.Domain.HRDepartment domainObject, AttachmentsSampleSystem.Generated.DTO.HRDepartmentFullDTO mappingObject);
        
        void MapHRDepartment(AttachmentsSampleSystem.Domain.HRDepartment domainObject, AttachmentsSampleSystem.Generated.DTO.HRDepartmentRichDTO mappingObject);
        
        void MapHRDepartment(AttachmentsSampleSystem.Generated.DTO.HRDepartmentStrictDTO mappingObject, AttachmentsSampleSystem.Domain.HRDepartment domainObject);
        
        void MapLocation(AttachmentsSampleSystem.Domain.Location domainObject, AttachmentsSampleSystem.Generated.DTO.LocationVisualDTO mappingObject);
        
        void MapLocation(AttachmentsSampleSystem.Domain.Location domainObject, AttachmentsSampleSystem.Generated.DTO.LocationSimpleDTO mappingObject);
        
        void MapLocation(AttachmentsSampleSystem.Domain.Location domainObject, AttachmentsSampleSystem.Generated.DTO.LocationFullDTO mappingObject);
        
        void MapLocation(AttachmentsSampleSystem.Domain.Location domainObject, AttachmentsSampleSystem.Generated.DTO.LocationRichDTO mappingObject);
        
        void MapLocation(AttachmentsSampleSystem.Generated.DTO.LocationStrictDTO mappingObject, AttachmentsSampleSystem.Domain.Location domainObject);
        
        void MapPersistentDomainObjectBase(AttachmentsSampleSystem.Domain.PersistentDomainObjectBase domainObject, AttachmentsSampleSystem.Generated.DTO.BasePersistentDTO mappingObject);
        
        AttachmentsSampleSystem.Domain.BusinessUnit ToBusinessUnit(AttachmentsSampleSystem.Generated.DTO.BusinessUnitIdentityDTO businessUnitIdentityDTO);
        
        AttachmentsSampleSystem.Domain.BusinessUnit ToBusinessUnit(AttachmentsSampleSystem.Generated.DTO.BusinessUnitStrictDTO businessUnitStrictDTO);
        
        AttachmentsSampleSystem.Domain.BusinessUnit ToBusinessUnit(AttachmentsSampleSystem.Generated.DTO.BusinessUnitStrictDTO businessUnitStrictDTO, bool allowCreate);
        
        AttachmentsSampleSystem.Domain.Employee ToEmployee(AttachmentsSampleSystem.Generated.DTO.EmployeeIdentityDTO employeeIdentityDTO);
        
        AttachmentsSampleSystem.Domain.Employee ToEmployee(AttachmentsSampleSystem.Generated.DTO.EmployeeStrictDTO employeeStrictDTO);
        
        AttachmentsSampleSystem.Domain.Employee ToEmployee(AttachmentsSampleSystem.Generated.DTO.EmployeeStrictDTO employeeStrictDTO, bool allowCreate);
        
        AttachmentsSampleSystem.Domain.Employee ToEmployee(AttachmentsSampleSystem.Generated.DTO.EmployeeUpdateDTO employeeUpdateDTO);
        
        AttachmentsSampleSystem.Domain.Employee ToEmployee(AttachmentsSampleSystem.Generated.DTO.EmployeeUpdateDTO employeeUpdateDTO, bool allowCreate);
        
        AttachmentsSampleSystem.Domain.HRDepartment ToHRDepartment(AttachmentsSampleSystem.Generated.DTO.HRDepartmentIdentityDTO hRDepartmentIdentityDTO);
        
        AttachmentsSampleSystem.Domain.HRDepartment ToHRDepartment(AttachmentsSampleSystem.Generated.DTO.HRDepartmentStrictDTO hRDepartmentStrictDTO);
        
        AttachmentsSampleSystem.Domain.HRDepartment ToHRDepartment(AttachmentsSampleSystem.Generated.DTO.HRDepartmentStrictDTO hRDepartmentStrictDTO, bool allowCreate);
        
        AttachmentsSampleSystem.Domain.Location ToLocation(AttachmentsSampleSystem.Generated.DTO.LocationIdentityDTO locationIdentityDTO);
        
        AttachmentsSampleSystem.Domain.Location ToLocation(AttachmentsSampleSystem.Generated.DTO.LocationStrictDTO locationStrictDTO);
        
        AttachmentsSampleSystem.Domain.Location ToLocation(AttachmentsSampleSystem.Generated.DTO.LocationStrictDTO locationStrictDTO, bool allowCreate);
    }
    
    public abstract partial class AttachmentsSampleSystemServerPrimitiveDTOMappingServiceBase : Framework.DomainDriven.DTOMappingService<AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext, AttachmentsSampleSystem.Domain.PersistentDomainObjectBase, AttachmentsSampleSystem.Domain.AuditPersistentDomainObjectBase, System.Guid, long>, AttachmentsSampleSystem.Generated.DTO.IAttachmentsSampleSystemDTOMappingService
    {
        
        protected AttachmentsSampleSystemServerPrimitiveDTOMappingServiceBase(AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext context) : 
                base(context)
        {
        }
        
        public virtual void MapAuditPersistentDomainObjectBase(AttachmentsSampleSystem.Domain.AuditPersistentDomainObjectBase domainObject, AttachmentsSampleSystem.Generated.DTO.BaseAuditPersistentDTO mappingObject)
        {
            mappingObject.Active = domainObject.Active;
            mappingObject.CreateDate = domainObject.CreateDate;
            mappingObject.CreatedBy = domainObject.CreatedBy;
            mappingObject.ModifiedBy = domainObject.ModifiedBy;
            mappingObject.ModifyDate = domainObject.ModifyDate;
            mappingObject.Version = domainObject.Version;
        }
        
        public virtual void MapBusinessUnit(AttachmentsSampleSystem.Domain.BusinessUnit domainObject, AttachmentsSampleSystem.Generated.DTO.BusinessUnitVisualDTO mappingObject)
        {
            mappingObject.Name = domainObject.Name;
        }
        
        public virtual void MapBusinessUnit(AttachmentsSampleSystem.Domain.BusinessUnit domainObject, AttachmentsSampleSystem.Generated.DTO.BusinessUnitSimpleDTO mappingObject)
        {
            mappingObject.Name = domainObject.Name;
            mappingObject.Period = domainObject.Period;
        }
        
        public virtual void MapBusinessUnit(AttachmentsSampleSystem.Domain.BusinessUnit domainObject, AttachmentsSampleSystem.Generated.DTO.BusinessUnitFullDTO mappingObject)
        {
            if (!object.ReferenceEquals(domainObject.Parent, null))
            {
                mappingObject.Parent = AttachmentsSampleSystem.Generated.DTO.LambdaHelper.ToSimpleDTO(domainObject.Parent, this);
            }
            else
            {
                mappingObject.Parent = null;
            }
        }
        
        public virtual void MapBusinessUnit(AttachmentsSampleSystem.Domain.BusinessUnit domainObject, AttachmentsSampleSystem.Generated.DTO.BusinessUnitRichDTO mappingObject)
        {
            mappingObject.Children = AttachmentsSampleSystem.Generated.DTO.LambdaHelper.ToRichDTOList(domainObject.Children, this);
        }
        
        public virtual void MapBusinessUnit(AttachmentsSampleSystem.Generated.DTO.BusinessUnitStrictDTO mappingObject, AttachmentsSampleSystem.Domain.BusinessUnit domainObject)
        {
            domainObject.Version = this.VersionService.GetVersion(mappingObject.Version, domainObject);
            domainObject.Name = mappingObject.Name;
        }
        
        public virtual void MapDomainObjectBase(AttachmentsSampleSystem.Domain.DomainObjectBase domainObject, AttachmentsSampleSystem.Generated.DTO.BaseAbstractDTO mappingObject)
        {
        }
        
        public virtual void MapEmployee(AttachmentsSampleSystem.Domain.Employee domainObject, AttachmentsSampleSystem.Generated.DTO.EmployeeSimpleDTO mappingObject)
        {
            mappingObject.AccountName = domainObject.AccountName;
            mappingObject.Age = domainObject.Age;
            mappingObject.BirthDate = domainObject.BirthDate;
            mappingObject.CellPhone = domainObject.CellPhone;
            mappingObject.CoreBusinessUnitPeriod = domainObject.CoreBusinessUnitPeriod;
            mappingObject.DismissDate = domainObject.DismissDate;
            mappingObject.EducationDuration = domainObject.EducationDuration;
            mappingObject.Email = domainObject.Email;
            mappingObject.ExternalId = domainObject.ExternalId;
            mappingObject.HireDate = domainObject.HireDate;
            mappingObject.Interphone = domainObject.Interphone;
            mappingObject.IsCandidate = domainObject.IsCandidate;
            mappingObject.Landlinephone = domainObject.Landlinephone;
            mappingObject.LastActionDate = domainObject.LastActionDate;
            mappingObject.Login = domainObject.Login;
            mappingObject.MailAccountName = domainObject.MailAccountName;
            mappingObject.NameEng = domainObject.NameEng;
            mappingObject.NameNative = domainObject.NameNative;
            mappingObject.NameRussian = domainObject.NameRussian;
            mappingObject.NonValidateVirtualProp = domainObject.NonValidateVirtualProp;
            mappingObject.PersonalCellPhone = domainObject.PersonalCellPhone;
            mappingObject.Pin = domainObject.Pin;
            mappingObject.PlannedHireDate = domainObject.PlannedHireDate;
            mappingObject.ValidateVirtualProp = domainObject.ValidateVirtualProp;
            mappingObject.WorkPeriod = domainObject.WorkPeriod;
        }
        
        public virtual void MapEmployee(AttachmentsSampleSystem.Domain.Employee domainObject, AttachmentsSampleSystem.Generated.DTO.EmployeeFullDTO mappingObject)
        {
            if (!object.ReferenceEquals(domainObject.CoreBusinessUnit, null))
            {
                mappingObject.CoreBusinessUnit = AttachmentsSampleSystem.Generated.DTO.LambdaHelper.ToSimpleDTO(domainObject.CoreBusinessUnit, this);
            }
            else
            {
                mappingObject.CoreBusinessUnit = null;
            }
            if (!object.ReferenceEquals(domainObject.HRDepartment, null))
            {
                mappingObject.HRDepartment = AttachmentsSampleSystem.Generated.DTO.LambdaHelper.ToSimpleDTO(domainObject.HRDepartment, this);
            }
            else
            {
                mappingObject.HRDepartment = null;
            }
            if (!object.ReferenceEquals(domainObject.Location, null))
            {
                mappingObject.Location = AttachmentsSampleSystem.Generated.DTO.LambdaHelper.ToSimpleDTO(domainObject.Location, this);
            }
            else
            {
                mappingObject.Location = null;
            }
            if (!object.ReferenceEquals(domainObject.Ppm, null))
            {
                mappingObject.Ppm = AttachmentsSampleSystem.Generated.DTO.LambdaHelper.ToSimpleDTO(domainObject.Ppm, this);
            }
            else
            {
                mappingObject.Ppm = null;
            }
            if (!object.ReferenceEquals(domainObject.VacationApprover, null))
            {
                mappingObject.VacationApprover = AttachmentsSampleSystem.Generated.DTO.LambdaHelper.ToSimpleDTO(domainObject.VacationApprover, this);
            }
            else
            {
                mappingObject.VacationApprover = null;
            }
        }
        
        public virtual void MapEmployee(AttachmentsSampleSystem.Generated.DTO.EmployeeStrictDTO mappingObject, AttachmentsSampleSystem.Domain.Employee domainObject)
        {
            domainObject.Version = this.VersionService.GetVersion(mappingObject.Version, domainObject);
            domainObject.Age = mappingObject.Age;
            domainObject.BirthDate = mappingObject.BirthDate;
            domainObject.EducationDuration = mappingObject.EducationDuration;
            domainObject.Email = mappingObject.Email;
            domainObject.ExternalId = mappingObject.ExternalId;
            domainObject.Interphone = mappingObject.Interphone;
            domainObject.Landlinephone = mappingObject.Landlinephone;
            domainObject.LastActionDate = mappingObject.LastActionDate;
            domainObject.Login = mappingObject.Login;
            domainObject.NameEng = mappingObject.NameEng;
            domainObject.NameNative = mappingObject.NameNative;
            domainObject.NameRussian = mappingObject.NameRussian;
            domainObject.NonValidateVirtualProp = mappingObject.NonValidateVirtualProp;
            domainObject.Pin = mappingObject.Pin;
            domainObject.PlannedHireDate = mappingObject.PlannedHireDate;
            if (!object.Equals(mappingObject.Ppm, default(AttachmentsSampleSystem.Generated.DTO.EmployeeIdentityDTO)))
            {
                domainObject.Ppm = this.ToEmployee(mappingObject.Ppm);
            }
            else
            {
                domainObject.Ppm = null;
            }
            if (!object.Equals(mappingObject.VacationApprover, default(AttachmentsSampleSystem.Generated.DTO.EmployeeIdentityDTO)))
            {
                domainObject.VacationApprover = this.ToEmployee(mappingObject.VacationApprover);
            }
            else
            {
                domainObject.VacationApprover = null;
            }
            domainObject.ValidateVirtualProp = mappingObject.ValidateVirtualProp;
            domainObject.WorkPeriod = mappingObject.WorkPeriod;
        }
        
        public virtual void MapEmployee(AttachmentsSampleSystem.Generated.DTO.EmployeeUpdateDTO mappingObject, AttachmentsSampleSystem.Domain.Employee domainObject)
        {
            domainObject.Version = this.VersionService.GetVersion(mappingObject.Version, domainObject);
            Framework.Core.Just<int> justAge = Framework.Core.PipeObjectExtensions.AsCast<Framework.Core.Just<int>>(mappingObject.Age);
            if (!object.ReferenceEquals(justAge, null))
            {
                domainObject.Age = justAge.Value;
            }
            Framework.Core.Just<System.DateTime?> justBirthDate = Framework.Core.PipeObjectExtensions.AsCast<Framework.Core.Just<System.DateTime?>>(mappingObject.BirthDate);
            if (!object.ReferenceEquals(justBirthDate, null))
            {
                domainObject.BirthDate = justBirthDate.Value;
            }
            Framework.Core.Just<Framework.Core.Period> justEducationDuration = Framework.Core.PipeObjectExtensions.AsCast<Framework.Core.Just<Framework.Core.Period>>(mappingObject.EducationDuration);
            if (!object.ReferenceEquals(justEducationDuration, null))
            {
                domainObject.EducationDuration = justEducationDuration.Value;
            }
            Framework.Core.Just<string> justEmail = Framework.Core.PipeObjectExtensions.AsCast<Framework.Core.Just<string>>(mappingObject.Email);
            if (!object.ReferenceEquals(justEmail, null))
            {
                domainObject.Email = justEmail.Value;
            }
            Framework.Core.Just<long> justExternalId = Framework.Core.PipeObjectExtensions.AsCast<Framework.Core.Just<long>>(mappingObject.ExternalId);
            if (!object.ReferenceEquals(justExternalId, null))
            {
                domainObject.ExternalId = justExternalId.Value;
            }
            Framework.Core.Just<string> justInterphone = Framework.Core.PipeObjectExtensions.AsCast<Framework.Core.Just<string>>(mappingObject.Interphone);
            if (!object.ReferenceEquals(justInterphone, null))
            {
                domainObject.Interphone = justInterphone.Value;
            }
            Framework.Core.Just<string> justLandlinephone = Framework.Core.PipeObjectExtensions.AsCast<Framework.Core.Just<string>>(mappingObject.Landlinephone);
            if (!object.ReferenceEquals(justLandlinephone, null))
            {
                domainObject.Landlinephone = justLandlinephone.Value;
            }
            Framework.Core.Just<System.DateTime?> justLastActionDate = Framework.Core.PipeObjectExtensions.AsCast<Framework.Core.Just<System.DateTime?>>(mappingObject.LastActionDate);
            if (!object.ReferenceEquals(justLastActionDate, null))
            {
                domainObject.LastActionDate = justLastActionDate.Value;
            }
            Framework.Core.Just<string> justLogin = Framework.Core.PipeObjectExtensions.AsCast<Framework.Core.Just<string>>(mappingObject.Login);
            if (!object.ReferenceEquals(justLogin, null))
            {
                domainObject.Login = justLogin.Value;
            }
            Framework.Core.Just<AttachmentsSampleSystem.Domain.Inline.FioShort> justNameEng = Framework.Core.PipeObjectExtensions.AsCast<Framework.Core.Just<AttachmentsSampleSystem.Domain.Inline.FioShort>>(mappingObject.NameEng);
            if (!object.ReferenceEquals(justNameEng, null))
            {
                domainObject.NameEng = justNameEng.Value;
            }
            Framework.Core.Just<AttachmentsSampleSystem.Domain.Inline.Fio> justNameNative = Framework.Core.PipeObjectExtensions.AsCast<Framework.Core.Just<AttachmentsSampleSystem.Domain.Inline.Fio>>(mappingObject.NameNative);
            if (!object.ReferenceEquals(justNameNative, null))
            {
                domainObject.NameNative = justNameNative.Value;
            }
            Framework.Core.Just<AttachmentsSampleSystem.Domain.Inline.Fio> justNameRussian = Framework.Core.PipeObjectExtensions.AsCast<Framework.Core.Just<AttachmentsSampleSystem.Domain.Inline.Fio>>(mappingObject.NameRussian);
            if (!object.ReferenceEquals(justNameRussian, null))
            {
                domainObject.NameRussian = justNameRussian.Value;
            }
            Framework.Core.Just<System.DateTime> justNonValidateVirtualProp = Framework.Core.PipeObjectExtensions.AsCast<Framework.Core.Just<System.DateTime>>(mappingObject.NonValidateVirtualProp);
            if (!object.ReferenceEquals(justNonValidateVirtualProp, null))
            {
                domainObject.NonValidateVirtualProp = justNonValidateVirtualProp.Value;
            }
            Framework.Core.Just<int?> justPin = Framework.Core.PipeObjectExtensions.AsCast<Framework.Core.Just<int?>>(mappingObject.Pin);
            if (!object.ReferenceEquals(justPin, null))
            {
                domainObject.Pin = justPin.Value;
            }
            Framework.Core.Just<System.DateTime?> justPlannedHireDate = Framework.Core.PipeObjectExtensions.AsCast<Framework.Core.Just<System.DateTime?>>(mappingObject.PlannedHireDate);
            if (!object.ReferenceEquals(justPlannedHireDate, null))
            {
                domainObject.PlannedHireDate = justPlannedHireDate.Value;
            }
            Framework.Core.Just<AttachmentsSampleSystem.Generated.DTO.EmployeeIdentityDTO> justPpm = Framework.Core.PipeObjectExtensions.AsCast<Framework.Core.Just<AttachmentsSampleSystem.Generated.DTO.EmployeeIdentityDTO>>(mappingObject.Ppm);
            if (!object.ReferenceEquals(justPpm, null))
            {
                if (!object.Equals(justPpm.Value, default(AttachmentsSampleSystem.Generated.DTO.EmployeeIdentityDTO)))
                {
                    domainObject.Ppm = this.ToEmployee(justPpm.Value);
                }
                else
                {
                    domainObject.Ppm = null;
                }
            }
            Framework.Core.Just<AttachmentsSampleSystem.Generated.DTO.EmployeeIdentityDTO> justVacationApprover = Framework.Core.PipeObjectExtensions.AsCast<Framework.Core.Just<AttachmentsSampleSystem.Generated.DTO.EmployeeIdentityDTO>>(mappingObject.VacationApprover);
            if (!object.ReferenceEquals(justVacationApprover, null))
            {
                if (!object.Equals(justVacationApprover.Value, default(AttachmentsSampleSystem.Generated.DTO.EmployeeIdentityDTO)))
                {
                    domainObject.VacationApprover = this.ToEmployee(justVacationApprover.Value);
                }
                else
                {
                    domainObject.VacationApprover = null;
                }
            }
            Framework.Core.Just<System.DateTime> justValidateVirtualProp = Framework.Core.PipeObjectExtensions.AsCast<Framework.Core.Just<System.DateTime>>(mappingObject.ValidateVirtualProp);
            if (!object.ReferenceEquals(justValidateVirtualProp, null))
            {
                domainObject.ValidateVirtualProp = justValidateVirtualProp.Value;
            }
            Framework.Core.Just<Framework.Core.Period> justWorkPeriod = Framework.Core.PipeObjectExtensions.AsCast<Framework.Core.Just<Framework.Core.Period>>(mappingObject.WorkPeriod);
            if (!object.ReferenceEquals(justWorkPeriod, null))
            {
                domainObject.WorkPeriod = justWorkPeriod.Value;
            }
        }
        
        public virtual void MapHRDepartment(AttachmentsSampleSystem.Domain.HRDepartment domainObject, AttachmentsSampleSystem.Generated.DTO.HRDepartmentVisualDTO mappingObject)
        {
            mappingObject.Name = domainObject.Name;
        }
        
        public virtual void MapHRDepartment(AttachmentsSampleSystem.Domain.HRDepartment domainObject, AttachmentsSampleSystem.Generated.DTO.HRDepartmentSimpleDTO mappingObject)
        {
            mappingObject.Code = domainObject.Code;
            mappingObject.CodeNative = domainObject.CodeNative;
            mappingObject.ExternalId = domainObject.ExternalId;
            mappingObject.IsLegal = domainObject.IsLegal;
            mappingObject.IsProduction = domainObject.IsProduction;
            mappingObject.Name = domainObject.Name;
            mappingObject.NameNative = domainObject.NameNative;
        }
        
        public virtual void MapHRDepartment(AttachmentsSampleSystem.Domain.HRDepartment domainObject, AttachmentsSampleSystem.Generated.DTO.HRDepartmentFullDTO mappingObject)
        {
            if (!object.ReferenceEquals(domainObject.Head, null))
            {
                mappingObject.Head = AttachmentsSampleSystem.Generated.DTO.LambdaHelper.ToSimpleDTO(domainObject.Head, this);
            }
            else
            {
                mappingObject.Head = null;
            }
            if (!object.ReferenceEquals(domainObject.Location, null))
            {
                mappingObject.Location = AttachmentsSampleSystem.Generated.DTO.LambdaHelper.ToSimpleDTO(domainObject.Location, this);
            }
            else
            {
                mappingObject.Location = null;
            }
            if (!object.ReferenceEquals(domainObject.Parent, null))
            {
                mappingObject.Parent = AttachmentsSampleSystem.Generated.DTO.LambdaHelper.ToSimpleDTO(domainObject.Parent, this);
            }
            else
            {
                mappingObject.Parent = null;
            }
        }
        
        public virtual void MapHRDepartment(AttachmentsSampleSystem.Domain.HRDepartment domainObject, AttachmentsSampleSystem.Generated.DTO.HRDepartmentRichDTO mappingObject)
        {
            mappingObject.Children = AttachmentsSampleSystem.Generated.DTO.LambdaHelper.ToRichDTOList(domainObject.Children, this);
        }
        
        public virtual void MapHRDepartment(AttachmentsSampleSystem.Generated.DTO.HRDepartmentStrictDTO mappingObject, AttachmentsSampleSystem.Domain.HRDepartment domainObject)
        {
            domainObject.Version = this.VersionService.GetVersion(mappingObject.Version, domainObject);
            domainObject.Active = mappingObject.Active;
            domainObject.Code = mappingObject.Code;
            domainObject.CodeNative = mappingObject.CodeNative;
            domainObject.ExternalId = mappingObject.ExternalId;
            if (!object.Equals(mappingObject.Head, default(AttachmentsSampleSystem.Generated.DTO.EmployeeIdentityDTO)))
            {
                domainObject.Head = this.ToEmployee(mappingObject.Head);
            }
            else
            {
                domainObject.Head = null;
            }
            domainObject.IsLegal = mappingObject.IsLegal;
            domainObject.IsProduction = mappingObject.IsProduction;
            domainObject.Name = mappingObject.Name;
            domainObject.NameNative = mappingObject.NameNative;
            if (!object.Equals(mappingObject.Parent, default(AttachmentsSampleSystem.Generated.DTO.HRDepartmentIdentityDTO)))
            {
                domainObject.Parent = this.ToHRDepartment(mappingObject.Parent);
            }
            else
            {
                domainObject.Parent = null;
            }
        }
        
        public virtual void MapLocation(AttachmentsSampleSystem.Domain.Location domainObject, AttachmentsSampleSystem.Generated.DTO.LocationVisualDTO mappingObject)
        {
            mappingObject.Name = domainObject.Name;
        }
        
        public virtual void MapLocation(AttachmentsSampleSystem.Domain.Location domainObject, AttachmentsSampleSystem.Generated.DTO.LocationSimpleDTO mappingObject)
        {
            mappingObject.Name = domainObject.Name;
        }
        
        public virtual void MapLocation(AttachmentsSampleSystem.Domain.Location domainObject, AttachmentsSampleSystem.Generated.DTO.LocationFullDTO mappingObject)
        {
            if (!object.ReferenceEquals(domainObject.Parent, null))
            {
                mappingObject.Parent = AttachmentsSampleSystem.Generated.DTO.LambdaHelper.ToSimpleDTO(domainObject.Parent, this);
            }
            else
            {
                mappingObject.Parent = null;
            }
        }
        
        public virtual void MapLocation(AttachmentsSampleSystem.Domain.Location domainObject, AttachmentsSampleSystem.Generated.DTO.LocationRichDTO mappingObject)
        {
            mappingObject.Children = AttachmentsSampleSystem.Generated.DTO.LambdaHelper.ToRichDTOList(domainObject.Children, this);
        }
        
        public virtual void MapLocation(AttachmentsSampleSystem.Generated.DTO.LocationStrictDTO mappingObject, AttachmentsSampleSystem.Domain.Location domainObject)
        {
            domainObject.Version = this.VersionService.GetVersion(mappingObject.Version, domainObject);
            domainObject.Active = mappingObject.Active;
            domainObject.Name = mappingObject.Name;
            if (!object.Equals(mappingObject.Parent, default(AttachmentsSampleSystem.Generated.DTO.LocationIdentityDTO)))
            {
                domainObject.Parent = this.ToLocation(mappingObject.Parent);
            }
            else
            {
                domainObject.Parent = null;
            }
        }
        
        public virtual void MapPersistentDomainObjectBase(AttachmentsSampleSystem.Domain.PersistentDomainObjectBase domainObject, AttachmentsSampleSystem.Generated.DTO.BasePersistentDTO mappingObject)
        {
            mappingObject.Id = domainObject.Id;
        }
        
        protected virtual void MapToDomainObject<TMappingObject, TDomainObject>(TMappingObject mappingObject, TDomainObject domainObject)
            where TMappingObject : Framework.DomainDriven.IMappingObject<AttachmentsSampleSystem.Generated.DTO.IAttachmentsSampleSystemDTOMappingService, TDomainObject>
            where TDomainObject : AttachmentsSampleSystem.Domain.DomainObjectBase
        {
            mappingObject.MapToDomainObject(this, domainObject);
        }
        
        public virtual AttachmentsSampleSystem.Domain.BusinessUnit ToBusinessUnit(AttachmentsSampleSystem.Generated.DTO.BusinessUnitIdentityDTO businessUnitIdentityDTO)
        {
            return this.GetById<AttachmentsSampleSystem.Domain.BusinessUnit>(businessUnitIdentityDTO.Id);
        }
        
        public virtual AttachmentsSampleSystem.Domain.BusinessUnit ToBusinessUnit(AttachmentsSampleSystem.Generated.DTO.BusinessUnitStrictDTO businessUnitStrictDTO)
        {
            return this.ToDomainObject<AttachmentsSampleSystem.Generated.DTO.BusinessUnitStrictDTO, AttachmentsSampleSystem.Domain.BusinessUnit>(businessUnitStrictDTO);
        }
        
        public virtual AttachmentsSampleSystem.Domain.BusinessUnit ToBusinessUnit(AttachmentsSampleSystem.Generated.DTO.BusinessUnitStrictDTO businessUnitStrictDTO, bool allowCreate)
        {
            if (allowCreate)
            {
                return this.ToDomainObject(businessUnitStrictDTO, () => new AttachmentsSampleSystem.Domain.BusinessUnit());
            }
            else
            {
                return this.ToBusinessUnit(businessUnitStrictDTO);
            }
        }
        
        protected virtual TDomainObject ToDomainObject<TMappingObject, TDomainObject>(TMappingObject mappingObject)
            where TMappingObject : Framework.DomainDriven.IMappingObject<AttachmentsSampleSystem.Generated.DTO.IAttachmentsSampleSystemDTOMappingService, TDomainObject, System.Guid>
            where TDomainObject : AttachmentsSampleSystem.Domain.PersistentDomainObjectBase
        {
            TDomainObject domainObject = this.GetById<TDomainObject>(mappingObject.Id, Framework.DomainDriven.IdCheckMode.CheckAll);
            this.MapToDomainObject(mappingObject, domainObject);
            return domainObject;
        }
        
        protected virtual TDomainObject ToDomainObject<TMappingObject, TDomainObject>(TMappingObject mappingObject, System.Func<TDomainObject> createFunc)
            where TMappingObject : Framework.DomainDriven.IMappingObject<AttachmentsSampleSystem.Generated.DTO.IAttachmentsSampleSystemDTOMappingService, TDomainObject, System.Guid>
            where TDomainObject : AttachmentsSampleSystem.Domain.PersistentDomainObjectBase
        {
            TDomainObject domainObject = this.GetByIdOrCreate<TDomainObject>(mappingObject.Id, createFunc);
            this.MapToDomainObject(mappingObject, domainObject);
            return domainObject;
        }
        
        protected virtual TDomainObject ToDomainObjectBase<TMappingObject, TDomainObject>(TMappingObject mappingObject)
            where TMappingObject : Framework.DomainDriven.IMappingObject<AttachmentsSampleSystem.Generated.DTO.IAttachmentsSampleSystemDTOMappingService, TDomainObject>
            where TDomainObject : AttachmentsSampleSystem.Domain.DomainObjectBase, new ()
        {
            TDomainObject domainObject = new TDomainObject();
            this.MapToDomainObject(mappingObject, domainObject);
            return domainObject;
        }
        
        public virtual AttachmentsSampleSystem.Domain.Employee ToEmployee(AttachmentsSampleSystem.Generated.DTO.EmployeeIdentityDTO employeeIdentityDTO)
        {
            return this.GetById<AttachmentsSampleSystem.Domain.Employee>(employeeIdentityDTO.Id);
        }
        
        public virtual AttachmentsSampleSystem.Domain.Employee ToEmployee(AttachmentsSampleSystem.Generated.DTO.EmployeeStrictDTO employeeStrictDTO)
        {
            return this.ToDomainObject<AttachmentsSampleSystem.Generated.DTO.EmployeeStrictDTO, AttachmentsSampleSystem.Domain.Employee>(employeeStrictDTO);
        }
        
        public virtual AttachmentsSampleSystem.Domain.Employee ToEmployee(AttachmentsSampleSystem.Generated.DTO.EmployeeStrictDTO employeeStrictDTO, bool allowCreate)
        {
            if (allowCreate)
            {
                return this.ToDomainObject(employeeStrictDTO, () => new AttachmentsSampleSystem.Domain.Employee());
            }
            else
            {
                return this.ToEmployee(employeeStrictDTO);
            }
        }
        
        public virtual AttachmentsSampleSystem.Domain.Employee ToEmployee(AttachmentsSampleSystem.Generated.DTO.EmployeeUpdateDTO employeeUpdateDTO)
        {
            return this.ToDomainObject<AttachmentsSampleSystem.Generated.DTO.EmployeeUpdateDTO, AttachmentsSampleSystem.Domain.Employee>(employeeUpdateDTO);
        }
        
        public virtual AttachmentsSampleSystem.Domain.Employee ToEmployee(AttachmentsSampleSystem.Generated.DTO.EmployeeUpdateDTO employeeUpdateDTO, bool allowCreate)
        {
            if (allowCreate)
            {
                return this.ToDomainObject(employeeUpdateDTO, () => new AttachmentsSampleSystem.Domain.Employee());
            }
            else
            {
                return this.ToEmployee(employeeUpdateDTO);
            }
        }
        
        public virtual AttachmentsSampleSystem.Domain.HRDepartment ToHRDepartment(AttachmentsSampleSystem.Generated.DTO.HRDepartmentIdentityDTO hRDepartmentIdentityDTO)
        {
            return this.GetById<AttachmentsSampleSystem.Domain.HRDepartment>(hRDepartmentIdentityDTO.Id);
        }
        
        public virtual AttachmentsSampleSystem.Domain.HRDepartment ToHRDepartment(AttachmentsSampleSystem.Generated.DTO.HRDepartmentStrictDTO hRDepartmentStrictDTO)
        {
            return this.ToDomainObject<AttachmentsSampleSystem.Generated.DTO.HRDepartmentStrictDTO, AttachmentsSampleSystem.Domain.HRDepartment>(hRDepartmentStrictDTO);
        }
        
        public virtual AttachmentsSampleSystem.Domain.HRDepartment ToHRDepartment(AttachmentsSampleSystem.Generated.DTO.HRDepartmentStrictDTO hRDepartmentStrictDTO, bool allowCreate)
        {
            if (allowCreate)
            {
                return this.ToDomainObject(hRDepartmentStrictDTO, () => new AttachmentsSampleSystem.Domain.HRDepartment());
            }
            else
            {
                return this.ToHRDepartment(hRDepartmentStrictDTO);
            }
        }
        
        public virtual AttachmentsSampleSystem.Domain.Location ToLocation(AttachmentsSampleSystem.Generated.DTO.LocationIdentityDTO locationIdentityDTO)
        {
            return this.GetById<AttachmentsSampleSystem.Domain.Location>(locationIdentityDTO.Id);
        }
        
        public virtual AttachmentsSampleSystem.Domain.Location ToLocation(AttachmentsSampleSystem.Generated.DTO.LocationStrictDTO locationStrictDTO)
        {
            return this.ToDomainObject<AttachmentsSampleSystem.Generated.DTO.LocationStrictDTO, AttachmentsSampleSystem.Domain.Location>(locationStrictDTO);
        }
        
        public virtual AttachmentsSampleSystem.Domain.Location ToLocation(AttachmentsSampleSystem.Generated.DTO.LocationStrictDTO locationStrictDTO, bool allowCreate)
        {
            if (allowCreate)
            {
                return this.ToDomainObject(locationStrictDTO, () => new AttachmentsSampleSystem.Domain.Location());
            }
            else
            {
                return this.ToLocation(locationStrictDTO);
            }
        }
    }
    
    public partial class AttachmentsSampleSystemServerPrimitiveDTOMappingService : AttachmentsSampleSystem.Generated.DTO.AttachmentsSampleSystemServerPrimitiveDTOMappingServiceBase
    {
        
        public AttachmentsSampleSystemServerPrimitiveDTOMappingService(AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext context) : 
                base(context)
        {
        }
    }
}
