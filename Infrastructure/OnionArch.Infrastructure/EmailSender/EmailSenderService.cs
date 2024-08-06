using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using OnionArch.Application.Exceptions.EmailSender;
using OnionArch.Application.InfrastructureModels;
using OnionArch.Application.Interfaces.Services;

namespace OnionArch.Infrastructure.EmailSender;
public class EmailSenderService : IEmailSenderService
{
    private readonly IConfiguration _configuration;

    public EmailSenderService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmailAsync(SendEmailRequest request)
    {
        string subject = _configuration["MailService:MailContent:" + Enum.GetName(request.MailType) + ":Subject"]!;
        string body = _configuration["MailService:MailContent:" + Enum.GetName(request.MailType) + ":Body"]!.Replace("{UrlExtension}", request.UrlExtension);

        if (string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(body))
        {
            throw new EmailNotConfiguredException("Email subject or body is not configured.");
        }

        var mailConfig = new MailConfig()
        {
            Host = _configuration["MailService:SMTP:Host"]!,
            Port = int.Parse(_configuration["MailService:SMTP:Port"]!),
            SenderName = _configuration["MailService:SenderInformation:Main:Name"]!,
            SenderMail = _configuration["MailService:SenderInformation:Main:Mail"]!,
            SenderPassword = _configuration["MailService:SenderInformation:Main:Password"]
        };

        bool mailConfigNullPropertyFound = mailConfig.GetType().GetProperties().Any(a => a.GetValue(mailConfig) == null);
        if (mailConfigNullPropertyFound)
        {
            throw new EmailNotConfiguredException("Mail config is not configured");
        }

        MailboxAddress mailboxAddressFrom = new(mailConfig.SenderName, mailConfig.SenderMail);
        MailboxAddress mailboxAddressTo = new("You", request.ReceiverMail);

        MimeMessage mimeMessage = new();
        mimeMessage.From.Add(mailboxAddressFrom);
        mimeMessage.To.Add(mailboxAddressTo);

        mimeMessage.Subject = subject;

        BodyBuilder bodyBuilder = new();
        bodyBuilder.HtmlBody = body;
        mimeMessage.Body = bodyBuilder.ToMessageBody();

        SmtpClient client = new();
        client.Connect(mailConfig.Host, mailConfig.Port, false);
        client.Authenticate(mailConfig.SenderMail, mailConfig.SenderPassword);
        client.Send(mimeMessage);
        client.Disconnect(true);
    }
}
