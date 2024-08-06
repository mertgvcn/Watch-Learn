using Microsoft.Extensions.DependencyInjection;
using OnionArch.Application.Features.Token;
using OnionArch.Application.Interfaces.Services;
using OnionArch.Infrastructure.Cancellation;
using OnionArch.Infrastructure.Cryption;
using OnionArch.Infrastructure.EmailSender;
using OnionArch.Infrastructure.HttpContext;
using OnionArch.Infrastructure.Transaction;

namespace OnionArch.Infrastructure;
public static class Registration
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ICancellationTokenService, CancellationTokenService>();
        services.AddScoped<ICryptionService, CryptionService>();
        services.AddScoped<IEmailSenderService, EmailSenderService>();
        services.AddScoped<IHttpContextService, HttpContextService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<ITransactionService, TransactionService>();
    }

}
