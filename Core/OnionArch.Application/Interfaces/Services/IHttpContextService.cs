namespace OnionArch.Application.Interfaces.Services;
public interface IHttpContextService
{
    Task<long> GetCurrentUserIdAsync();
}
