using OnionArch.Domain.Enumerators;

namespace OnionArch.Application.InfrastructureModels;

public class SendEmailRequest
{
    public string ReceiverMail { get; set; }

    public MailTypes MailType { get; set; }

    public string? UrlExtension { get; set; }
}
