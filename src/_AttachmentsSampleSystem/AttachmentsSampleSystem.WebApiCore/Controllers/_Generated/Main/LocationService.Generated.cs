﻿namespace AttachmentsSampleSystem.WebApiCore.Controllers.Main
{
    using AttachmentsSampleSystem.Generated.DTO;
    
    
    [Microsoft.AspNetCore.Mvc.ApiControllerAttribute()]
    [Microsoft.AspNetCore.Mvc.ApiVersionAttribute("1.0")]
    [Microsoft.AspNetCore.Mvc.RouteAttribute("api/v{version:apiVersion}/[controller]")]
    public partial class LocationController : Framework.DomainDriven.WebApiNetCore.ApiControllerBase<AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext, Framework.DomainDriven.ServiceModel.Service.EvaluatedData<AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext, AttachmentsSampleSystem.Generated.DTO.IAttachmentsSampleSystemDTOMappingService>>
    {
        
        /// <summary>
        /// Get Location (FullDTO) by identity
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPostAttribute()]
        [Microsoft.AspNetCore.Mvc.RouteAttribute("GetFullLocation")]
        public virtual AttachmentsSampleSystem.Generated.DTO.LocationFullDTO GetFullLocation([Microsoft.AspNetCore.Mvc.FromBodyAttribute()] AttachmentsSampleSystem.Generated.DTO.LocationIdentityDTO locationIdentity)
        {
            return this.Evaluate(Framework.DomainDriven.DBSessionMode.Read, evaluateData => this.GetFullLocationInternal(locationIdentity, evaluateData));
        }
        
        /// <summary>
        /// Get Location (FullDTO) by name
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPostAttribute()]
        [Microsoft.AspNetCore.Mvc.RouteAttribute("GetFullLocationByName")]
        public virtual AttachmentsSampleSystem.Generated.DTO.LocationFullDTO GetFullLocationByName([Microsoft.AspNetCore.Mvc.FromBodyAttribute()] string locationName)
        {
            return this.Evaluate(Framework.DomainDriven.DBSessionMode.Read, evaluateData => this.GetFullLocationByNameInternal(locationName, evaluateData));
        }
        
        protected virtual AttachmentsSampleSystem.Generated.DTO.LocationFullDTO GetFullLocationByNameInternal(string locationName, Framework.DomainDriven.ServiceModel.Service.EvaluatedData<AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext, AttachmentsSampleSystem.Generated.DTO.IAttachmentsSampleSystemDTOMappingService> evaluateData)
        {
            AttachmentsSampleSystem.BLL.ILocationBLL bll = evaluateData.Context.Logics.LocationFactory.Create(Framework.SecuritySystem.BLLSecurityMode.View);
            AttachmentsSampleSystem.Domain.Location domainObject = Framework.DomainDriven.BLL.DefaultDomainBLLBaseExtensions.GetByName(bll, locationName, true, evaluateData.Context.FetchService.GetContainer<AttachmentsSampleSystem.Domain.Location>(Framework.Transfering.ViewDTOType.FullDTO));
            return AttachmentsSampleSystem.Generated.DTO.LambdaHelper.ToFullDTO(domainObject, evaluateData.MappingService);
        }
        
        protected virtual AttachmentsSampleSystem.Generated.DTO.LocationFullDTO GetFullLocationInternal(AttachmentsSampleSystem.Generated.DTO.LocationIdentityDTO locationIdentity, Framework.DomainDriven.ServiceModel.Service.EvaluatedData<AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext, AttachmentsSampleSystem.Generated.DTO.IAttachmentsSampleSystemDTOMappingService> evaluateData)
        {
            AttachmentsSampleSystem.BLL.ILocationBLL bll = evaluateData.Context.Logics.LocationFactory.Create(Framework.SecuritySystem.BLLSecurityMode.View);
            AttachmentsSampleSystem.Domain.Location domainObject = bll.GetById(locationIdentity.Id, true, evaluateData.Context.FetchService.GetContainer<AttachmentsSampleSystem.Domain.Location>(Framework.Transfering.ViewDTOType.FullDTO));
            return AttachmentsSampleSystem.Generated.DTO.LambdaHelper.ToFullDTO(domainObject, evaluateData.MappingService);
        }
        
        /// <summary>
        /// Get full list of Locations (FullDTO)
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPostAttribute()]
        [Microsoft.AspNetCore.Mvc.RouteAttribute("GetFullLocations")]
        public virtual System.Collections.Generic.IEnumerable<AttachmentsSampleSystem.Generated.DTO.LocationFullDTO> GetFullLocations()
        {
            return this.Evaluate(Framework.DomainDriven.DBSessionMode.Read, evaluateData => this.GetFullLocationsInternal(evaluateData));
        }
        
        /// <summary>
        /// Get Locations (FullDTO) by idents
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPostAttribute()]
        [Microsoft.AspNetCore.Mvc.RouteAttribute("GetFullLocationsByIdents")]
        public virtual System.Collections.Generic.IEnumerable<AttachmentsSampleSystem.Generated.DTO.LocationFullDTO> GetFullLocationsByIdents([Microsoft.AspNetCore.Mvc.FromBodyAttribute()] AttachmentsSampleSystem.Generated.DTO.LocationIdentityDTO[] locationIdents)
        {
            return this.Evaluate(Framework.DomainDriven.DBSessionMode.Read, evaluateData => this.GetFullLocationsByIdentsInternal(locationIdents, evaluateData));
        }
        
        protected virtual System.Collections.Generic.IEnumerable<AttachmentsSampleSystem.Generated.DTO.LocationFullDTO> GetFullLocationsByIdentsInternal(AttachmentsSampleSystem.Generated.DTO.LocationIdentityDTO[] locationIdents, Framework.DomainDriven.ServiceModel.Service.EvaluatedData<AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext, AttachmentsSampleSystem.Generated.DTO.IAttachmentsSampleSystemDTOMappingService> evaluateData)
        {
            AttachmentsSampleSystem.BLL.ILocationBLL bll = evaluateData.Context.Logics.LocationFactory.Create(Framework.SecuritySystem.BLLSecurityMode.View);
            return AttachmentsSampleSystem.Generated.DTO.LambdaHelper.ToFullDTOList(bll.GetListByIdents(locationIdents, evaluateData.Context.FetchService.GetContainer<AttachmentsSampleSystem.Domain.Location>(Framework.Transfering.ViewDTOType.FullDTO)), evaluateData.MappingService);
        }
        
        protected virtual System.Collections.Generic.IEnumerable<AttachmentsSampleSystem.Generated.DTO.LocationFullDTO> GetFullLocationsInternal(Framework.DomainDriven.ServiceModel.Service.EvaluatedData<AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext, AttachmentsSampleSystem.Generated.DTO.IAttachmentsSampleSystemDTOMappingService> evaluateData)
        {
            AttachmentsSampleSystem.BLL.ILocationBLL bll = evaluateData.Context.Logics.LocationFactory.Create(Framework.SecuritySystem.BLLSecurityMode.View);
            return AttachmentsSampleSystem.Generated.DTO.LambdaHelper.ToFullDTOList(bll.GetFullList(evaluateData.Context.FetchService.GetContainer<AttachmentsSampleSystem.Domain.Location>(Framework.Transfering.ViewDTOType.FullDTO)), evaluateData.MappingService);
        }
        
        /// <summary>
        /// Get Location (RichDTO) by identity
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPostAttribute()]
        [Microsoft.AspNetCore.Mvc.RouteAttribute("GetRichLocation")]
        public virtual AttachmentsSampleSystem.Generated.DTO.LocationRichDTO GetRichLocation([Microsoft.AspNetCore.Mvc.FromBodyAttribute()] AttachmentsSampleSystem.Generated.DTO.LocationIdentityDTO locationIdentity)
        {
            return this.Evaluate(Framework.DomainDriven.DBSessionMode.Read, evaluateData => this.GetRichLocationInternal(locationIdentity, evaluateData));
        }
        
        /// <summary>
        /// Get Location (RichDTO) by name
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPostAttribute()]
        [Microsoft.AspNetCore.Mvc.RouteAttribute("GetRichLocationByName")]
        public virtual AttachmentsSampleSystem.Generated.DTO.LocationRichDTO GetRichLocationByName([Microsoft.AspNetCore.Mvc.FromBodyAttribute()] string locationName)
        {
            return this.Evaluate(Framework.DomainDriven.DBSessionMode.Read, evaluateData => this.GetRichLocationByNameInternal(locationName, evaluateData));
        }
        
        protected virtual AttachmentsSampleSystem.Generated.DTO.LocationRichDTO GetRichLocationByNameInternal(string locationName, Framework.DomainDriven.ServiceModel.Service.EvaluatedData<AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext, AttachmentsSampleSystem.Generated.DTO.IAttachmentsSampleSystemDTOMappingService> evaluateData)
        {
            AttachmentsSampleSystem.BLL.ILocationBLL bll = evaluateData.Context.Logics.LocationFactory.Create(Framework.SecuritySystem.BLLSecurityMode.View);
            AttachmentsSampleSystem.Domain.Location domainObject = Framework.DomainDriven.BLL.DefaultDomainBLLBaseExtensions.GetByName(bll, locationName, true, evaluateData.Context.FetchService.GetContainer<AttachmentsSampleSystem.Domain.Location>(Framework.Transfering.ViewDTOType.FullDTO));
            return AttachmentsSampleSystem.Generated.DTO.LambdaHelper.ToRichDTO(domainObject, evaluateData.MappingService);
        }
        
        protected virtual AttachmentsSampleSystem.Generated.DTO.LocationRichDTO GetRichLocationInternal(AttachmentsSampleSystem.Generated.DTO.LocationIdentityDTO locationIdentity, Framework.DomainDriven.ServiceModel.Service.EvaluatedData<AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext, AttachmentsSampleSystem.Generated.DTO.IAttachmentsSampleSystemDTOMappingService> evaluateData)
        {
            AttachmentsSampleSystem.BLL.ILocationBLL bll = evaluateData.Context.Logics.LocationFactory.Create(Framework.SecuritySystem.BLLSecurityMode.View);
            AttachmentsSampleSystem.Domain.Location domainObject = bll.GetById(locationIdentity.Id, true, evaluateData.Context.FetchService.GetContainer<AttachmentsSampleSystem.Domain.Location>(Framework.Transfering.ViewDTOType.FullDTO));
            return AttachmentsSampleSystem.Generated.DTO.LambdaHelper.ToRichDTO(domainObject, evaluateData.MappingService);
        }
        
        /// <summary>
        /// Get Location (SimpleDTO) by identity
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPostAttribute()]
        [Microsoft.AspNetCore.Mvc.RouteAttribute("GetSimpleLocation")]
        public virtual AttachmentsSampleSystem.Generated.DTO.LocationSimpleDTO GetSimpleLocation([Microsoft.AspNetCore.Mvc.FromBodyAttribute()] AttachmentsSampleSystem.Generated.DTO.LocationIdentityDTO locationIdentity)
        {
            return this.Evaluate(Framework.DomainDriven.DBSessionMode.Read, evaluateData => this.GetSimpleLocationInternal(locationIdentity, evaluateData));
        }
        
        /// <summary>
        /// Get Location (SimpleDTO) by name
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPostAttribute()]
        [Microsoft.AspNetCore.Mvc.RouteAttribute("GetSimpleLocationByName")]
        public virtual AttachmentsSampleSystem.Generated.DTO.LocationSimpleDTO GetSimpleLocationByName([Microsoft.AspNetCore.Mvc.FromBodyAttribute()] string locationName)
        {
            return this.Evaluate(Framework.DomainDriven.DBSessionMode.Read, evaluateData => this.GetSimpleLocationByNameInternal(locationName, evaluateData));
        }
        
        protected virtual AttachmentsSampleSystem.Generated.DTO.LocationSimpleDTO GetSimpleLocationByNameInternal(string locationName, Framework.DomainDriven.ServiceModel.Service.EvaluatedData<AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext, AttachmentsSampleSystem.Generated.DTO.IAttachmentsSampleSystemDTOMappingService> evaluateData)
        {
            AttachmentsSampleSystem.BLL.ILocationBLL bll = evaluateData.Context.Logics.LocationFactory.Create(Framework.SecuritySystem.BLLSecurityMode.View);
            AttachmentsSampleSystem.Domain.Location domainObject = Framework.DomainDriven.BLL.DefaultDomainBLLBaseExtensions.GetByName(bll, locationName, true, evaluateData.Context.FetchService.GetContainer<AttachmentsSampleSystem.Domain.Location>(Framework.Transfering.ViewDTOType.SimpleDTO));
            return AttachmentsSampleSystem.Generated.DTO.LambdaHelper.ToSimpleDTO(domainObject, evaluateData.MappingService);
        }
        
        protected virtual AttachmentsSampleSystem.Generated.DTO.LocationSimpleDTO GetSimpleLocationInternal(AttachmentsSampleSystem.Generated.DTO.LocationIdentityDTO locationIdentity, Framework.DomainDriven.ServiceModel.Service.EvaluatedData<AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext, AttachmentsSampleSystem.Generated.DTO.IAttachmentsSampleSystemDTOMappingService> evaluateData)
        {
            AttachmentsSampleSystem.BLL.ILocationBLL bll = evaluateData.Context.Logics.LocationFactory.Create(Framework.SecuritySystem.BLLSecurityMode.View);
            AttachmentsSampleSystem.Domain.Location domainObject = bll.GetById(locationIdentity.Id, true, evaluateData.Context.FetchService.GetContainer<AttachmentsSampleSystem.Domain.Location>(Framework.Transfering.ViewDTOType.SimpleDTO));
            return AttachmentsSampleSystem.Generated.DTO.LambdaHelper.ToSimpleDTO(domainObject, evaluateData.MappingService);
        }
        
        /// <summary>
        /// Get full list of Locations (SimpleDTO)
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPostAttribute()]
        [Microsoft.AspNetCore.Mvc.RouteAttribute("GetSimpleLocations")]
        public virtual System.Collections.Generic.IEnumerable<AttachmentsSampleSystem.Generated.DTO.LocationSimpleDTO> GetSimpleLocations()
        {
            return this.Evaluate(Framework.DomainDriven.DBSessionMode.Read, evaluateData => this.GetSimpleLocationsInternal(evaluateData));
        }
        
        /// <summary>
        /// Get Locations (SimpleDTO) by idents
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPostAttribute()]
        [Microsoft.AspNetCore.Mvc.RouteAttribute("GetSimpleLocationsByIdents")]
        public virtual System.Collections.Generic.IEnumerable<AttachmentsSampleSystem.Generated.DTO.LocationSimpleDTO> GetSimpleLocationsByIdents([Microsoft.AspNetCore.Mvc.FromBodyAttribute()] AttachmentsSampleSystem.Generated.DTO.LocationIdentityDTO[] locationIdents)
        {
            return this.Evaluate(Framework.DomainDriven.DBSessionMode.Read, evaluateData => this.GetSimpleLocationsByIdentsInternal(locationIdents, evaluateData));
        }
        
        protected virtual System.Collections.Generic.IEnumerable<AttachmentsSampleSystem.Generated.DTO.LocationSimpleDTO> GetSimpleLocationsByIdentsInternal(AttachmentsSampleSystem.Generated.DTO.LocationIdentityDTO[] locationIdents, Framework.DomainDriven.ServiceModel.Service.EvaluatedData<AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext, AttachmentsSampleSystem.Generated.DTO.IAttachmentsSampleSystemDTOMappingService> evaluateData)
        {
            AttachmentsSampleSystem.BLL.ILocationBLL bll = evaluateData.Context.Logics.LocationFactory.Create(Framework.SecuritySystem.BLLSecurityMode.View);
            return AttachmentsSampleSystem.Generated.DTO.LambdaHelper.ToSimpleDTOList(bll.GetListByIdents(locationIdents, evaluateData.Context.FetchService.GetContainer<AttachmentsSampleSystem.Domain.Location>(Framework.Transfering.ViewDTOType.SimpleDTO)), evaluateData.MappingService);
        }
        
        protected virtual System.Collections.Generic.IEnumerable<AttachmentsSampleSystem.Generated.DTO.LocationSimpleDTO> GetSimpleLocationsInternal(Framework.DomainDriven.ServiceModel.Service.EvaluatedData<AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext, AttachmentsSampleSystem.Generated.DTO.IAttachmentsSampleSystemDTOMappingService> evaluateData)
        {
            AttachmentsSampleSystem.BLL.ILocationBLL bll = evaluateData.Context.Logics.LocationFactory.Create(Framework.SecuritySystem.BLLSecurityMode.View);
            return AttachmentsSampleSystem.Generated.DTO.LambdaHelper.ToSimpleDTOList(bll.GetFullList(evaluateData.Context.FetchService.GetContainer<AttachmentsSampleSystem.Domain.Location>(Framework.Transfering.ViewDTOType.SimpleDTO)), evaluateData.MappingService);
        }
        
        /// <summary>
        /// Get Location (VisualDTO) by identity
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPostAttribute()]
        [Microsoft.AspNetCore.Mvc.RouteAttribute("GetVisualLocation")]
        public virtual AttachmentsSampleSystem.Generated.DTO.LocationVisualDTO GetVisualLocation([Microsoft.AspNetCore.Mvc.FromBodyAttribute()] AttachmentsSampleSystem.Generated.DTO.LocationIdentityDTO locationIdentity)
        {
            return this.Evaluate(Framework.DomainDriven.DBSessionMode.Read, evaluateData => this.GetVisualLocationInternal(locationIdentity, evaluateData));
        }
        
        /// <summary>
        /// Get Location (VisualDTO) by name
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPostAttribute()]
        [Microsoft.AspNetCore.Mvc.RouteAttribute("GetVisualLocationByName")]
        public virtual AttachmentsSampleSystem.Generated.DTO.LocationVisualDTO GetVisualLocationByName([Microsoft.AspNetCore.Mvc.FromBodyAttribute()] string locationName)
        {
            return this.Evaluate(Framework.DomainDriven.DBSessionMode.Read, evaluateData => this.GetVisualLocationByNameInternal(locationName, evaluateData));
        }
        
        protected virtual AttachmentsSampleSystem.Generated.DTO.LocationVisualDTO GetVisualLocationByNameInternal(string locationName, Framework.DomainDriven.ServiceModel.Service.EvaluatedData<AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext, AttachmentsSampleSystem.Generated.DTO.IAttachmentsSampleSystemDTOMappingService> evaluateData)
        {
            AttachmentsSampleSystem.BLL.ILocationBLL bll = evaluateData.Context.Logics.LocationFactory.Create(Framework.SecuritySystem.BLLSecurityMode.View);
            AttachmentsSampleSystem.Domain.Location domainObject = Framework.DomainDriven.BLL.DefaultDomainBLLBaseExtensions.GetByName(bll, locationName, true, evaluateData.Context.FetchService.GetContainer<AttachmentsSampleSystem.Domain.Location>(Framework.Transfering.ViewDTOType.VisualDTO));
            return AttachmentsSampleSystem.Generated.DTO.LambdaHelper.ToVisualDTO(domainObject, evaluateData.MappingService);
        }
        
        protected virtual AttachmentsSampleSystem.Generated.DTO.LocationVisualDTO GetVisualLocationInternal(AttachmentsSampleSystem.Generated.DTO.LocationIdentityDTO locationIdentity, Framework.DomainDriven.ServiceModel.Service.EvaluatedData<AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext, AttachmentsSampleSystem.Generated.DTO.IAttachmentsSampleSystemDTOMappingService> evaluateData)
        {
            AttachmentsSampleSystem.BLL.ILocationBLL bll = evaluateData.Context.Logics.LocationFactory.Create(Framework.SecuritySystem.BLLSecurityMode.View);
            AttachmentsSampleSystem.Domain.Location domainObject = bll.GetById(locationIdentity.Id, true, evaluateData.Context.FetchService.GetContainer<AttachmentsSampleSystem.Domain.Location>(Framework.Transfering.ViewDTOType.VisualDTO));
            return AttachmentsSampleSystem.Generated.DTO.LambdaHelper.ToVisualDTO(domainObject, evaluateData.MappingService);
        }
        
        /// <summary>
        /// Get full list of Locations (VisualDTO)
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPostAttribute()]
        [Microsoft.AspNetCore.Mvc.RouteAttribute("GetVisualLocations")]
        public virtual System.Collections.Generic.IEnumerable<AttachmentsSampleSystem.Generated.DTO.LocationVisualDTO> GetVisualLocations()
        {
            return this.Evaluate(Framework.DomainDriven.DBSessionMode.Read, evaluateData => this.GetVisualLocationsInternal(evaluateData));
        }
        
        /// <summary>
        /// Get Locations (VisualDTO) by idents
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPostAttribute()]
        [Microsoft.AspNetCore.Mvc.RouteAttribute("GetVisualLocationsByIdents")]
        public virtual System.Collections.Generic.IEnumerable<AttachmentsSampleSystem.Generated.DTO.LocationVisualDTO> GetVisualLocationsByIdents([Microsoft.AspNetCore.Mvc.FromBodyAttribute()] AttachmentsSampleSystem.Generated.DTO.LocationIdentityDTO[] locationIdents)
        {
            return this.Evaluate(Framework.DomainDriven.DBSessionMode.Read, evaluateData => this.GetVisualLocationsByIdentsInternal(locationIdents, evaluateData));
        }
        
        protected virtual System.Collections.Generic.IEnumerable<AttachmentsSampleSystem.Generated.DTO.LocationVisualDTO> GetVisualLocationsByIdentsInternal(AttachmentsSampleSystem.Generated.DTO.LocationIdentityDTO[] locationIdents, Framework.DomainDriven.ServiceModel.Service.EvaluatedData<AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext, AttachmentsSampleSystem.Generated.DTO.IAttachmentsSampleSystemDTOMappingService> evaluateData)
        {
            AttachmentsSampleSystem.BLL.ILocationBLL bll = evaluateData.Context.Logics.LocationFactory.Create(Framework.SecuritySystem.BLLSecurityMode.View);
            return AttachmentsSampleSystem.Generated.DTO.LambdaHelper.ToVisualDTOList(bll.GetListByIdents(locationIdents, evaluateData.Context.FetchService.GetContainer<AttachmentsSampleSystem.Domain.Location>(Framework.Transfering.ViewDTOType.VisualDTO)), evaluateData.MappingService);
        }
        
        protected virtual System.Collections.Generic.IEnumerable<AttachmentsSampleSystem.Generated.DTO.LocationVisualDTO> GetVisualLocationsInternal(Framework.DomainDriven.ServiceModel.Service.EvaluatedData<AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext, AttachmentsSampleSystem.Generated.DTO.IAttachmentsSampleSystemDTOMappingService> evaluateData)
        {
            AttachmentsSampleSystem.BLL.ILocationBLL bll = evaluateData.Context.Logics.LocationFactory.Create(Framework.SecuritySystem.BLLSecurityMode.View);
            return AttachmentsSampleSystem.Generated.DTO.LambdaHelper.ToVisualDTOList(bll.GetFullList(evaluateData.Context.FetchService.GetContainer<AttachmentsSampleSystem.Domain.Location>(Framework.Transfering.ViewDTOType.VisualDTO)), evaluateData.MappingService);
        }
        
        /// <summary>
        /// Remove Location
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPostAttribute()]
        [Microsoft.AspNetCore.Mvc.RouteAttribute("RemoveLocation")]
        public virtual void RemoveLocation([Microsoft.AspNetCore.Mvc.FromBodyAttribute()] AttachmentsSampleSystem.Generated.DTO.LocationIdentityDTO locationIdent)
        {
            this.Evaluate(Framework.DomainDriven.DBSessionMode.Write, evaluateData => this.RemoveLocationInternal(locationIdent, evaluateData));
        }
        
        protected virtual void RemoveLocationInternal(AttachmentsSampleSystem.Generated.DTO.LocationIdentityDTO locationIdent, Framework.DomainDriven.ServiceModel.Service.EvaluatedData<AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext, AttachmentsSampleSystem.Generated.DTO.IAttachmentsSampleSystemDTOMappingService> evaluateData)
        {
            AttachmentsSampleSystem.BLL.ILocationBLL bll = evaluateData.Context.Logics.LocationFactory.Create(Framework.SecuritySystem.BLLSecurityMode.Edit);
            this.RemoveLocationInternal(locationIdent, evaluateData, bll);
        }
        
        protected virtual void RemoveLocationInternal(AttachmentsSampleSystem.Generated.DTO.LocationIdentityDTO locationIdent, Framework.DomainDriven.ServiceModel.Service.EvaluatedData<AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext, AttachmentsSampleSystem.Generated.DTO.IAttachmentsSampleSystemDTOMappingService> evaluateData, AttachmentsSampleSystem.BLL.ILocationBLL bll)
        {
            AttachmentsSampleSystem.Domain.Location domainObject = bll.GetById(locationIdent.Id, true);
            bll.Remove(domainObject);
        }
        
        /// <summary>
        /// Save Locations
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPostAttribute()]
        [Microsoft.AspNetCore.Mvc.RouteAttribute("SaveLocation")]
        public virtual AttachmentsSampleSystem.Generated.DTO.LocationIdentityDTO SaveLocation([Microsoft.AspNetCore.Mvc.FromBodyAttribute()] AttachmentsSampleSystem.Generated.DTO.LocationStrictDTO locationStrict)
        {
            return this.Evaluate(Framework.DomainDriven.DBSessionMode.Write, evaluateData => this.SaveLocationInternal(locationStrict, evaluateData));
        }
        
        protected virtual AttachmentsSampleSystem.Generated.DTO.LocationIdentityDTO SaveLocationInternal(AttachmentsSampleSystem.Generated.DTO.LocationStrictDTO locationStrict, Framework.DomainDriven.ServiceModel.Service.EvaluatedData<AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext, AttachmentsSampleSystem.Generated.DTO.IAttachmentsSampleSystemDTOMappingService> evaluateData)
        {
            AttachmentsSampleSystem.BLL.ILocationBLL bll = evaluateData.Context.Logics.LocationFactory.Create(Framework.SecuritySystem.BLLSecurityMode.Edit);
            return this.SaveLocationInternal(locationStrict, evaluateData, bll);
        }
        
        protected virtual AttachmentsSampleSystem.Generated.DTO.LocationIdentityDTO SaveLocationInternal(AttachmentsSampleSystem.Generated.DTO.LocationStrictDTO locationStrict, Framework.DomainDriven.ServiceModel.Service.EvaluatedData<AttachmentsSampleSystem.BLL.IAttachmentsSampleSystemBLLContext, AttachmentsSampleSystem.Generated.DTO.IAttachmentsSampleSystemDTOMappingService> evaluateData, AttachmentsSampleSystem.BLL.ILocationBLL bll)
        {
            AttachmentsSampleSystem.Domain.Location domainObject = Framework.DomainDriven.BLL.DefaultDomainBLLBaseExtensions.GetByIdOrCreate(bll, locationStrict.Id);
            locationStrict.MapToDomainObject(evaluateData.MappingService, domainObject);
            bll.Save(domainObject);
            return AttachmentsSampleSystem.Generated.DTO.LambdaHelper.ToIdentityDTO(domainObject);
        }
    }
}
