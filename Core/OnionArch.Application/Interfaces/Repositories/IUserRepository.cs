using OnionArch.Domain.Entities;

namespace OnionArch.Application.Interfaces.Repositories;
public interface IUserRepository : IBaseRepository<User>
{
    Task<bool> UserExistsByEmailAsync(string email, CancellationToken cancellationToken);
    Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
}
