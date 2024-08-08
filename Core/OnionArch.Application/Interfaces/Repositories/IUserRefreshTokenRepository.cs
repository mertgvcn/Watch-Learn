using OnionArch.Domain.Entities;

namespace OnionArch.Application.Interfaces.Repositories;
public interface IUserRefreshTokenRepository : IBaseRepository<UserRefreshToken>
{
    Task<UserRefreshToken> GetByTokenAsync(string token, CancellationToken cancellationToken);
    Task<UserRefreshToken?> GetByUserIdAsync(long userId, CancellationToken cancellationToken);
}
