namespace OnionArch.Application.Exceptions.EmailSender;
public class EmailNotConfiguredException : Exception
{
    public EmailNotConfiguredException(string message) : base(message) { }
}
