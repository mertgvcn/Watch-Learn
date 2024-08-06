using OnionArch.Application.Features.Users.Models;
using OnionArch.Domain.Entities;

namespace OnionArch.Application.Interfaces.Services;
public interface IUserService
{
    Task<List<UserViewModel>> GetAllUsersAsync(CancellationToken cancellationToken);
    Task<UserViewModel> GetUserByIdAsync(long id, CancellationToken cancellationToken);
    Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
    Task<User> AddUserAsync(User request, CancellationToken cancellationToken);
    Task UpdateUserAsync(UpdateUserRequest request, CancellationToken cancellationToken);
    Task DeleteUserAsync(long id, CancellationToken cancellationToken);
}
