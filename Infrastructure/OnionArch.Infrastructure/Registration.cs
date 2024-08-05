﻿using Microsoft.Extensions.DependencyInjection;
using OnionArch.Application.Interfaces.Services;
using OnionArch.Infrastructure.Cancellation.Services;

namespace OnionArch.Infrastructure;
public static class Registration
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ICancellationTokenService, CancellationTokenService>();
    }
}
