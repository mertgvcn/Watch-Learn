using OnionArch.Application.InfrastructureModels;

namespace OnionArch.Application.Interfaces.Services;
public interface IEmailSenderService
{
    Task SendEmailAsync(SendEmailRequest request);
}
