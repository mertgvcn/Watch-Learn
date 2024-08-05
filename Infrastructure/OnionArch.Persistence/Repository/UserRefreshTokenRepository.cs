using OnionArch.Application.Interfaces.Repositories;
using OnionArch.Domain.Entities;
using OnionArch.Persistence.Context;

namespace OnionArch.Persistence.Repository;
public sealed class UserRefreshTokenRepository(AppDbContext context) : BaseRepository<UserRefreshToken>(context), IUserRefreshTokenRepository
{
}