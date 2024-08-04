using OnionArch.Application.Interfaces.Services;

namespace OnionArch.Infrastructure.Cancellation;
public class CancellationTokenService : IDisposable, ICancellationTokenService
{
    private readonly CancellationTokenSource _cancellationTokenSource;

    public CancellationTokenService()
    {
        _cancellationTokenSource = new();
    }
    public void Dispose()
    {
        Cancel();
        GC.SuppressFinalize(this);
    }
    public void Cancel()
    {
        _cancellationTokenSource.Cancel();
    }
    public void Register(CancellationToken cancellationToken)
    {
        cancellationToken.Register(() => _cancellationTokenSource.Cancel());
    }
    public CancellationToken cancellationToken => _cancellationTokenSource.Token;
}
