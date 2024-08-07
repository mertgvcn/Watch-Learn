using OnionArch.Application.Features.Users.Models;

namespace OnionArch.Application.Interfaces.Services;
public interface IUserService
{
    Task<List<UserViewModel>> GetAllUsersAsync(CancellationToken cancellationToken);
    Task UpdateUserAsync(UpdateUserRequest request, CancellationToken cancellationToken);
}
