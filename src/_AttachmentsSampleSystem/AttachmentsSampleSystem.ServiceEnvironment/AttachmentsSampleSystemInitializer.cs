﻿using System;
using System.Collections.Generic;

using AttachmentsSampleSystem.BLL;

using Framework.Authorization.BLL;
using Framework.DomainDriven.BLL;
using Framework.DomainDriven.ServiceModel.IAD;

namespace AttachmentsSampleSystem.ServiceEnvironment;

public class AttachmentsSampleSystemInitializer
{
    private readonly IContextEvaluator<IAttachmentsSampleSystemBLLContext> contextEvaluator;

    private readonly IInitializeManager initializeManager;

    public AttachmentsSampleSystemInitializer(IContextEvaluator<IAttachmentsSampleSystemBLLContext> contextEvaluator, IInitializeManager initializeManager)
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
        this.contextEvaluator.Evaluate(
                                       DBSessionMode.Write,
                                       context =>
                                       {
                                           context.Configuration.Logics.NamedLock.CheckInit();
                                       });

        this.contextEvaluator.Evaluate(
                                       DBSessionMode.Write,
                                       context =>
                                       {
                                           context.Logics.NamedLock.CheckInit();
                                       });

        this.contextEvaluator.Evaluate(
                                       DBSessionMode.Write,
                                       context =>
                                       {
                                           context.Authorization.InitSecurityOperations();

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
}