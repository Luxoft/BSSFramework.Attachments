﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

using Framework.Attachments.Domain;
using Framework.Authorization.BLL;
using Framework.Core;
using Framework.DomainDriven;
using Framework.DomainDriven.BLL;
using Framework.DomainDriven.BLL.Security;
using Framework.DomainDriven.Tracking;
using Framework.Exceptions;
using Framework.HierarchicalExpand;
using Framework.QueryLanguage;
using Framework.SecuritySystem;



namespace Framework.Attachments.BLL
{
    public partial class AttachmentsBLLContext
    {
        private readonly Lazy<Dictionary<TargetSystem, ITargetSystemService>> lazyTargetSystemServiceCache;

        private readonly IDictionaryCache<Type, DomainType> domainTypeCache;

        public AttachmentsBLLContext(
            IServiceProvider serviceProvider,
            IOperationEventSenderContainer<PersistentDomainObjectBase> operationSenders,
            ITrackingService<PersistentDomainObjectBase> trackingService,
            IAccessDeniedExceptionService accessDeniedExceptionService,
            IStandartExpressionBuilder standartExpressionBuilder,
            IAttachmentsValidator validator,
            IHierarchicalObjectExpanderFactory<Guid> hierarchicalObjectExpanderFactory,
            IFetchService<PersistentDomainObjectBase, FetchBuildRule> fetchService,
            IRootSecurityService<PersistentDomainObjectBase> securityService,
            IAttachmentsBLLFactoryContainer logics,
            IAuthorizationBLLContext authorizationBLLContext,
            Framework.Configuration.BLL.IConfigurationBLLContext configurationBLLContext,
            IEnumerable<ITargetSystemService> targetSystemServices,
            IAttachmentsBLLContextSettings settings)
            : base(serviceProvider, operationSenders, trackingService, accessDeniedExceptionService, standartExpressionBuilder, validator, hierarchicalObjectExpanderFactory, fetchService)
        {
            this.SecurityService = securityService ?? throw new ArgumentNullException(nameof(securityService));
            this.Logics = logics ?? throw new ArgumentNullException(nameof(logics));

            this.Authorization = authorizationBLLContext ?? throw new ArgumentNullException(nameof(authorizationBLLContext));
            this.Configuration = configurationBLLContext ?? throw new ArgumentNullException(nameof(configurationBLLContext));

            this.lazyTargetSystemServiceCache = LazyHelper.Create(() => targetSystemServices.ToDictionary(s => s.TargetSystem));

            this.domainTypeCache = new DictionaryCache<Type, DomainType>(type =>

                this.GetTargetSystemService(type, false).Maybe(targetService => this.GetDomainType(targetService, type))).WithLock();

            this.TypeResolver = settings.TypeResolver;
        }

        public IRootSecurityService<PersistentDomainObjectBase> SecurityService { get; }

        public override IAttachmentsBLLFactoryContainer Logics { get; }

        public IAuthorizationBLLContext Authorization { get; }

        public Framework.Configuration.BLL.IConfigurationBLLContext Configuration { get; }

        public ITypeResolver<string> TypeResolver { get; }

        public ITargetSystemService GetPersistentTargetSystemService(TargetSystem targetSystem)
        {
            if (targetSystem == null) throw new ArgumentNullException(nameof(targetSystem));

            return this.lazyTargetSystemServiceCache.Value[targetSystem];
        }

        public IEnumerable<ITargetSystemService> GetPersistentTargetSystemServices()
        {
            return this.lazyTargetSystemServiceCache.Value.Values;
        }

        public DomainType GetDomainType(Type type, bool throwOnNotFound)
        {
            var domainType = this.domainTypeCache[type];

            if (domainType == null && throwOnNotFound)
            {
                throw new BusinessLogicException("TargetSystem with domainType \"{0}\" not found", type.FullName);
            }

            return domainType;
        }

        public ITargetSystemService GetTargetSystemService(Type domainType, bool throwOnNotFound)
        {
            if (domainType == null) throw new ArgumentNullException(nameof(domainType));

            if (throwOnNotFound)
            {
                return this.lazyTargetSystemServiceCache.Value.Values.Single(
                                                                             service => service.IsAssignable(domainType),
                                                                             () => new BusinessLogicException($"Target System for type {domainType.Name} not found"),
                                                                             () => new BusinessLogicException($"To many Target Systems for type {domainType.Name}"));
            }
            else
            {
                return this.lazyTargetSystemServiceCache.Value.Values.SingleOrDefault(
                 service => service.IsAssignable(domainType),
                 () => new BusinessLogicException($"Target System for type {domainType.Name} not found"));
            }
        }

        private DomainType GetDomainType(ITargetSystemService targetService, Type type)
        {
            var domainTypes = this.Logics.DomainType.GetListBy(domainType => domainType.TargetSystem == targetService.TargetSystem
                                                                             && domainType.Name == type.Name
                                                                             && domainType.NameSpace == type.Namespace);

            if (domainTypes.Count > 1)
            {
                var message = $"Configuration database contains more than one record for domain type '{domainTypes.First().Name}' and target system '{targetService.TargetSystem.Name}'. Remove excess records and restart application.";
                throw new ConfigurationErrorsException(message);
            }

            return domainTypes.SingleOrDefault();
        }
    }
}
