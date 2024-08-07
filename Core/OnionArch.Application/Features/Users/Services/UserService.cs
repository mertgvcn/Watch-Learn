using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Exceptions.Users;
using OnionArch.Application.Features.Users.Models;
using OnionArch.Application.Interfaces.Repositories;
using OnionArch.Application.Interfaces.Services;

namespace OnionArch.Application.Features.Users.Services;
public sealed class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<List<UserViewModel>> GetAllUsersAsync(CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAll()
            .ProjectTo<UserViewModel>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return users;
    }

    public async Task UpdateUserAsync(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByIdAsync(request.Id);

        if (existingUser == null)
            throw new UserNotFoundException($"User with Id {request.Id} returned null");

        _mapper.Map(request, existingUser);
        await _userRepository.UpdateAsync(existingUser, cancellationToken);
    }

}
