using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Exceptions.Features.Users;
using OnionArch.Application.Features.Users.Models;
using OnionArch.Application.Interfaces.Repositories;
using OnionArch.Application.Interfaces.Services;
using OnionArch.Domain.Entities;

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

    public async Task<UserViewModel> GetUserByIdAsync(long id, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAll()
            .Where(x => x.Id == id)
            .ProjectTo<UserViewModel>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(cancellationToken);

        if (user == null)
            throw new UserNotFoundException($"User with Id {id} returned null");

        return user;
    }

    public async Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAll()
            .Where(x => x.Email == email)
            .SingleOrDefaultAsync(cancellationToken);

        if (user == null)
            throw new UserNotFoundException($"User with email {email} returned null");

        return user;
    }

    public async Task AddUserAsync(AddUserRequest request, CancellationToken cancellationToken)
    {
        var newUser = _mapper.Map<User>(request);

        await _userRepository.AddAsync(newUser, cancellationToken);
    }

    public async Task UpdateUserAsync(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByIdAsync(request.Id);

        if (existingUser == null)
            throw new UserNotFoundException($"User with Id {request.Id} returned null");

        _mapper.Map(request, existingUser);
        await _userRepository.UpdateAsync(existingUser, cancellationToken);
    }

    public async Task DeleteUserAsync(long id, CancellationToken cancellationToken)
    {
        await _userRepository.DeleteAsync(id, cancellationToken);
    }
}
