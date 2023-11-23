using System;
using System.Collections.Generic;

using AttachmentsSampleSystem.BLL;

using Framework.Authorization.SecuritySystem.Initialize;
using Framework.DomainDriven;
using Framework.DomainDriven.ServiceModel.IAD;
using Microsoft.Extensions.DependencyInjection;

namespace AttachmentsSampleSystem.ServiceEnvironment;

public class AttachmentsSampleSystemInitializer
{
    private readonly IServiceEvaluator<IAttachmentsSampleSystemBLLContext> contextEvaluator;

    private readonly IInitializeManager initializeManager;

    public AttachmentsSampleSystemInitializer(IServiceEvaluator<IAttachmentsSampleSystemBLLContext> contextEvaluator, IInitializeManager initializeManager)
    {
        this.contextEvaluator = contextEvaluator;
        this.initializeManager = initializeManager;
    }

    public void Initialize()
    {
        this.initializeManager.InitializeOperation(this.InternalInitialize);
    }

    private void InternalInitialize()
    {
        this.contextEvaluator.Evaluate(DBSessionMode.Write, context => context.Configuration.Logics.NamedLock.CheckInit());
        this.contextEvaluator.Evaluate(DBSessionMode.Write, context => context.Logics.NamedLock.CheckInit());

        this.InitSecurity<IAuthorizationEntityTypeInitializer>();
        this.InitSecurity<IAuthorizationOperationInitializer>();
        this.InitSecurity<IAuthorizationBusinessRoleInitializer>();

        this.contextEvaluator.Evaluate(
                                       DBSessionMode.Write,
                                       context =>
                                       {
                                           context.Configuration.Logics.TargetSystem.RegisterBase();
                                           context.Configuration.Logics.TargetSystem.Register<AttachmentsSampleSystem.Domain.PersistentDomainObjectBase>(true, true);

                                           var extTypes = new Dictionary<Guid, Type>
                                                          {
                                                                  { new Guid("{79AF1049-3EC0-46A7-A769-62A24AD4F74E}"), typeof(Framework.Configuration.Domain.Sequence) }
                                                          };

                                           context.Configuration.Logics.TargetSystem.Register<Framework.Configuration.Domain.PersistentDomainObjectBase>(false, true, extTypes: extTypes);
                                           context.Configuration.Logics.TargetSystem.Register<Framework.Authorization.Domain.PersistentDomainObjectBase>(false, true);
                                       });

        this.contextEvaluator.Evaluate(
                                       DBSessionMode.Write,
                                       context =>
                                       {
                                           context.Configuration.Logics.SystemConstant.Initialize(typeof(AttachmentsSampleSystemSystemConstant));
                                       });
    }
    private void InitSecurity<TSecurityInitializer>()
            where TSecurityInitializer : ISecurityInitializer
    {
        this.contextEvaluator.Evaluate(
                                       DBSessionMode.Write,
                                       context =>
                                       {
                                           context.ServiceProvider
                                                  .GetRequiredService<TSecurityInitializer>()
                                                  .Init()
                                                  .GetAwaiter()
                                                  .GetResult();
                                       });
    }
}
