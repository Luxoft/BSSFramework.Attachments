using System;
using System.Linq;
using System.Linq.Expressions;

using Framework.Attachments.Domain;
using Framework.Core;
using Framework.DomainDriven.BLL;
using Framework.DomainDriven.BLL.Security;
using Framework.Persistent;
using Framework.SecuritySystem;

using Microsoft.Extensions.DependencyInjection;

namespace Framework.Attachments.BLL
{
    public class AttachmentSecurityService<TBllContext, TPersistentDomainObjectBase> : BLLContextContainer<IAttachmentsBLLContext>, IAttachmentSecurityProviderSource

        where TBllContext : class, ITypeResolverContainer<string>, ISecurityBLLContext<TPersistentDomainObjectBase, Guid>, ISecurityServiceContainer<IRootSecurityService<TPersistentDomainObjectBase>>


        where TPersistentDomainObjectBase : class, IIdentityObject<Guid>
    {
        private readonly TBllContext targetSystemContext;

        public AttachmentSecurityService(IAttachmentsBLLContext context, TBllContext targetSystemContext)
            : base(context)
        {
            this.targetSystemContext = targetSystemContext ?? throw new ArgumentNullException(nameof(targetSystemContext));
        }


        public ISecurityProvider<TDomainObject> GetAttachmentSecurityProvider<TDomainObject>(Expression<Func<TDomainObject, AttachmentContainer>> containerPath, DomainType mainDomainType, BLLSecurityMode securityMode)
            where TDomainObject : PersistentDomainObjectBase
        {
            if (containerPath == null) throw new ArgumentNullException(nameof(containerPath));
            if (mainDomainType == null) throw new ArgumentNullException(nameof(mainDomainType));

            return new GetAttachmentSecurityProviderProcessor<TDomainObject>(this.targetSystemContext, this.Context, containerPath, securityMode).Process(mainDomainType.Name);
        }


        private class GetAttachmentSecurityProviderProcessor<TDomainObject> : TypeResolverDomainObjectProcessor<TBllContext, TPersistentDomainObjectBase, ISecurityProvider<TDomainObject>>
            where TDomainObject : PersistentDomainObjectBase
        {
            private readonly IAttachmentsBLLContext mainContext;

            private readonly Expression<Func<TDomainObject, AttachmentContainer>> containerPath;
            private readonly BLLSecurityMode securityMode;


            public GetAttachmentSecurityProviderProcessor(TBllContext context, IAttachmentsBLLContext mainContext, Expression<Func<TDomainObject, AttachmentContainer>> containerPath, BLLSecurityMode securityMode)
                : base(context)
            {
                this.mainContext = mainContext;
                this.containerPath = containerPath ?? throw new ArgumentNullException(nameof(containerPath));
                this.securityMode = securityMode;
            }


            protected override ISecurityProvider<TDomainObject> Process<TTargetSystemDomainObject>()
            {
                var targetSystemSecurityProvider = this.GetTargetSecurityProvider<TTargetSystemDomainObject>();

                return new AttachmentSecurityProvider<TDomainObject, TTargetSystemDomainObject>(targetSystemSecurityProvider, this.Context, this.containerPath);
            }

            private ISecurityProvider<TTargetSystemDomainObject> GetTargetSecurityProvider<TTargetSystemDomainObject>()
                    where TTargetSystemDomainObject : class, TPersistentDomainObjectBase
            {
                var customAttachmentOperationInfo = this.Context.ServiceProvider.GetService<AttachmentDomainObjectSecurityOperationInfo<TTargetSystemDomainObject>>();

                if (customAttachmentOperationInfo != null)
                {
                    var targetDomainService = this.Context.ServiceProvider.GetRequiredService<IDomainSecurityService<TTargetSystemDomainObject>>();

                    switch (this.securityMode)
                    {
                        case BLLSecurityMode.View when customAttachmentOperationInfo.ViewOperation != null:
                            return targetDomainService.GetSecurityProvider(customAttachmentOperationInfo.ViewOperation);

                        case BLLSecurityMode.Edit when customAttachmentOperationInfo.EditOperation != null:
                            return targetDomainService.GetSecurityProvider(customAttachmentOperationInfo.EditOperation);

                    }
                }

                return this.Context.SecurityService.GetSecurityProvider<TTargetSystemDomainObject>(this.securityMode);
            }
        }

        public class AttachmentSecurityProvider<TDomainObject, TTargetSystemDomainObject> : ISecurityProvider<TDomainObject>

            where TDomainObject : PersistentDomainObjectBase
            where TTargetSystemDomainObject : class, TPersistentDomainObjectBase
        {
            private readonly Expression<Func<TDomainObject, AttachmentContainer>> containerPath;

            private readonly ISecurityProvider<TTargetSystemDomainObject> targetSystemSecurityProvider;

            private static readonly LambdaCompileCache CompileCache = new LambdaCompileCache();


            public AttachmentSecurityProvider(ISecurityProvider<TTargetSystemDomainObject> targetSystemSecurityProvider, TBllContext context, Expression<Func<TDomainObject, AttachmentContainer>> containerPath)
            {
                this.Context = context;

                this.containerPath = containerPath ?? throw new ArgumentNullException(nameof(containerPath));
                this.targetSystemSecurityProvider = targetSystemSecurityProvider;
            }

            public TBllContext Context { get; }

            public IQueryable<TDomainObject> InjectFilter(IQueryable<TDomainObject> queryable)
            {
                var mainQueryable = this.Context.Logics.Default.Create<TTargetSystemDomainObject>().GetUnsecureQueryable();

                var filteredMainQueryable = this.targetSystemSecurityProvider.InjectFilter(mainQueryable);

                return filteredMainQueryable.Join(queryable, v => v.Id, this.containerPath.Select(v => v.ObjectId), (_, domainObject) => domainObject);
            }

            public bool HasAccess(TDomainObject domainObject)
            {
                if (domainObject == null) throw new ArgumentNullException(nameof(domainObject));

                var targetDomainObject = this.Context.Logics.Default.Create<TTargetSystemDomainObject>().GetById(this.containerPath.Eval(domainObject, CompileCache).ObjectId, true);

                return this.targetSystemSecurityProvider.HasAccess(targetDomainObject);
            }

            public UnboundedList<string> GetAccessors(TDomainObject domainObject)
            {
                var mainBll = this.Context.Logics.Implemented.Create<TTargetSystemDomainObject>();

                var obj = mainBll.GetById(this.containerPath.Eval(domainObject).ObjectId, true);

                return this.targetSystemSecurityProvider.GetAccessors(obj);
            }
        }
    }
}
