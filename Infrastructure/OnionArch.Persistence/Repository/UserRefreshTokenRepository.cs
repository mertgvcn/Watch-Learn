using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Interfaces.Repositories;
using OnionArch.Domain.Entities;
using OnionArch.Persistence.Context;

namespace OnionArch.Persistence.Repository;
public sealed class UserRefreshTokenRepository(AppDbContext context) : BaseRepository<UserRefreshToken>(context), IUserRefreshTokenRepository
{
    public async Task<UserRefreshToken> GetByTokenAsync(string token, CancellationToken cancellationToken)
    {
        return await GetAll().SingleAsync(x => x.Token == token, cancellationToken);
    }

    public async Task<UserRefreshToken> GetByUserIdAsync(long userId, CancellationToken cancellationToken)
    {
        return await GetAll().SingleAsync(x => x.UserId == userId, cancellationToken);
    }
}