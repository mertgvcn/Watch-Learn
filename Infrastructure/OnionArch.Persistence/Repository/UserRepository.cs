using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Interfaces.Repositories;
using OnionArch.Domain.Entities;
using OnionArch.Persistence.Context;

namespace OnionArch.Persistence.Repository;
public sealed class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
{
    public async Task<bool> UserExistsByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await GetAll().AnyAsync(a => a.Email == email, cancellationToken);
    }
    public async Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await GetAll()
            .Where(x => x.Email == email)
            .SingleOrDefaultAsync(cancellationToken); ;
    }
}
