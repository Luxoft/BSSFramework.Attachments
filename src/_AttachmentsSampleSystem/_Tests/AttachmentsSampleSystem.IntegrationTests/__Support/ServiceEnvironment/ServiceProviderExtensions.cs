﻿using System;

using Attachments.IntegrationTests;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace AttachmentsSampleSystem.IntegrationTests.__Support.ServiceEnvironment;

public static class ServiceProviderExtensions
{
    public static ControllerEvaluator<TController> GetDefaultControllerEvaluator<TController>(this IServiceProvider serviceProvider, string principalName = null)
            where TController : ControllerBase
    {
        var controllerEvaluator = serviceProvider.GetRequiredService<ControllerEvaluator<TController>>();

        return principalName == null ? controllerEvaluator : controllerEvaluator.WithImpersonate(principalName);
    }
}
