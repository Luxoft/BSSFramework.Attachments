using System;
using System.Linq.Expressions;

using Attachments.IntegrationTests;

using Framework.Core;
using Framework.DomainDriven;
using Framework.DomainDriven.BLL;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using AttachmentsSampleSystem.BLL;
using AttachmentsSampleSystem.IntegrationTests.__Support.ServiceEnvironment;

namespace AttachmentsSampleSystem.IntegrationTests;

public static class RootServiceProviderContainerExtensions
{
    public static TResult EvaluateController<TController, TResult>(this IRootServiceProviderContainer controllerEvaluator, Expression<Func<TController, TResult>> func)
            where TController : ControllerBase
    {
        return controllerEvaluator.RootServiceProvider.GetRequiredService<ControllerEvaluator<TController>>().Evaluate(func);
    }

    public static void EvaluateController<TController>(this IRootServiceProviderContainer controllerEvaluator, Expression<Action<TController>> action)
            where TController : ControllerBase
    {
        controllerEvaluator.RootServiceProvider.GetRequiredService<ControllerEvaluator<TController>>().Evaluate(action);
    }

    public static IContextEvaluator<IAttachmentsSampleSystemBLLContext> GetContextEvaluator(this IRootServiceProviderContainer rootServiceProviderContainer)
    {
        return rootServiceProviderContainer.RootServiceProvider.GetRequiredService<IContextEvaluator<IAttachmentsSampleSystemBLLContext>>();
    }

    public static IDateTimeService GetDateTimeService(this IRootServiceProviderContainer rootServiceProviderContainer)
    {
        return rootServiceProviderContainer.RootServiceProvider.GetRequiredService<IDateTimeService>();
    }




    public static TResult EvaluateWrite<TResult>(this IRootServiceProviderContainer rootServiceProviderContainer, Func<IAttachmentsSampleSystemBLLContext, TResult> func)
    {
        return rootServiceProviderContainer.GetContextEvaluator().Evaluate(DBSessionMode.Write, func);
    }

    public static void EvaluateRead(this IRootServiceProviderContainer rootServiceProviderContainer, Action<IAttachmentsSampleSystemBLLContext> action)
    {
        rootServiceProviderContainer.GetContextEvaluator().Evaluate(DBSessionMode.Read, action);
    }

    public static T EvaluateRead<T>(this IRootServiceProviderContainer rootServiceProviderContainer, Func<IAttachmentsSampleSystemBLLContext, T> action)
    {
        return rootServiceProviderContainer.GetContextEvaluator().Evaluate(DBSessionMode.Read, action);
    }

    public static void EvaluateWrite(this IRootServiceProviderContainer rootServiceProviderContainer, Action<IAttachmentsSampleSystemBLLContext> func)
    {
        rootServiceProviderContainer.GetContextEvaluator().Evaluate(DBSessionMode.Write, context => { func(context); return Ignore.Value; });
    }
}
