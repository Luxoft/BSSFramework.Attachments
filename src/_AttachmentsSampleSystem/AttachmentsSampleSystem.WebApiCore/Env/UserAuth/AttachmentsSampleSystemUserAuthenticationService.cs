﻿using System;
using System.Threading.Tasks;

using Framework.Core.Services;

using AttachmentsSampleSystem.WebApiCore.Env;

using Framework.DomainDriven;

namespace AttachmentsSampleSystem.WebApiCore;

public class AttachmentsSampleSystemUserAuthenticationService : IUserAuthenticationService, IImpersonateService
{
    private readonly IDefaultUserAuthenticationService defaultAuthenticationService;

    public AttachmentsSampleSystemUserAuthenticationService(IDefaultUserAuthenticationService defaultAuthenticationService)
    {
        this.defaultAuthenticationService = defaultAuthenticationService;
    }

    public string GetUserName() => this.CustomUserName ?? this.defaultAuthenticationService.GetUserName();

    public string CustomUserName { get; private set; }

    public async Task<T> WithImpersonateAsync<T>(string customUserName, Func<Task<T>> func)
    {
        var prev = this.CustomUserName;

        this.CustomUserName = customUserName;

        try
        {
            return await func();
        }
        finally
        {
            this.CustomUserName = prev;
        }
    }
}
