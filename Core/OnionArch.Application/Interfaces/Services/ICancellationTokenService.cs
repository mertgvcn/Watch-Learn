
namespace OnionArch.Application.Interfaces.Services;

public interface ICancellationTokenService
{
    CancellationToken cancellationToken { get; }

    void Cancel();
    void Dispose();
    void Register(CancellationToken cancellationToken);
}