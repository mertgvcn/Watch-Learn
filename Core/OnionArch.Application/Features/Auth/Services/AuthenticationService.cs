using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Exceptions.Auth;
using OnionArch.Application.Features.Auth.Models;
using OnionArch.Application.InfrastructureModels.Models;
using OnionArch.Application.Interfaces.Repositories;
using OnionArch.Application.Interfaces.Services;
using OnionArch.Domain.Entities;
using OnionArch.Domain.Enumerators;
using System.Security.Claims;

namespace OnionArch.Application.Features.Auth.Services;
public sealed class AuthenticationService : IAuthenticationService
{
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;
    private readonly ICryptionService _cryptionService;
    private readonly IUserRefreshTokenRepository _userRefreshTokenRepository;
    private readonly ITransactionService _transactionService;
    private readonly IHttpContextService _httpContextService;
    private readonly IEmailSenderService _emailSenderService;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(
        IUserService userService,
        ITokenService tokenService,
        ICryptionService cryptionService,
        IUserRefreshTokenRepository userRefreshTokenRepository,
        ITransactionService transactionService,
        IHttpContextService httpContextService,
        IEmailSenderService emailSenderService,
        IMapper mapper,
        IUserRepository userRepository
        )
    {
        _userService = userService;
        _tokenService = tokenService;
        _cryptionService = cryptionService;
        _userRefreshTokenRepository = userRefreshTokenRepository;
        _transactionService = transactionService;
        _httpContextService = httpContextService;
        _emailSenderService = emailSenderService;
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request, CancellationToken cancellationToken)
    {
        using var transaction = await _transactionService.CreateTransactionAsync(cancellationToken);

        var user = await _userRepository.GetUserByEmailAsync(request.Email, cancellationToken);
        var plainPassword = await _cryptionService.Decrypt(request.EncryptedPassword);

        if (!BCrypt.Net.BCrypt.Verify(plainPassword, user.Password))
            throw new UnauthorizedAccessException("User credentials incorrect");

        var generatedToken = await _tokenService.GenerateTokenAsync(user, cancellationToken);

        await AddRefreshToken(user.Id, generatedToken, cancellationToken);

        await transaction.CommitAsync(cancellationToken);
        return new UserLoginResponse()
        {
            AccessToken = generatedToken.AccessToken,
            AccessTokenExpireDate = generatedToken.AccessTokenExpireDate,
            RefreshToken = generatedToken.RefreshToken,
            RefreshTokenExpireDate = generatedToken.RefreshTokenExpireDate
        };
    }

    public async Task RegisterStudentAsync(UserRegisterRequest request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetUserByEmailAsync(request.Email, cancellationToken);
        if (existingUser != null)
            throw new UserAlreadyExistsException("This user is already exists");

        string plainPassword = await _cryptionService.Decrypt(request.EncryptedPassword);
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(plainPassword);

        var newUser = _mapper.Map<User>(request);
        newUser.Role = Roles.Student;
        newUser.Password = hashedPassword;

        await _userRepository.AddAsync(newUser, cancellationToken);
    }

    public async Task<GenerateTokenResponse> CreateAccessTokenByRefreshTokenAsync(CreateAccessTokenByRefreshTokenRequest request, CancellationToken cancellationToken)
    {
        var principal = _tokenService.GetPrincipalFromExpiredAccessToken(request.AccessToken)!;

        if (principal.FindFirstValue(ClaimTypes.NameIdentifier) is null)
            throw new UnauthorizedAccessException();

        var userId = long.Parse(await _cryptionService.Decrypt(principal.FindFirstValue(ClaimTypes.NameIdentifier)!));

        //bu kısım user service e eklenecek bir method ile tek satırda yapılabilir.
        var user = await _userRepository.GetByIdAsync(userId, cancellationToken);
        var refreshToken = await _userRefreshTokenRepository.GetAll().SingleOrDefaultAsync(x => x.UserId == userId, cancellationToken);

        if (refreshToken is null || refreshToken.Token != request.RefreshToken || refreshToken.ExpireDate < DateTime.UtcNow)
            throw new UnauthorizedAccessException();

        var token = await _tokenService.GenerateTokenAsync(user, cancellationToken);
        token.RefreshToken = request.RefreshToken;
        token.RefreshTokenExpireDate = refreshToken.ExpireDate;

        return token;
    }

    public async Task RevokeRefreshTokenAsync(CancellationToken cancellationToken)
    {
        var userId = await _httpContextService.GetCurrentUserIdAsync();

        using var transaction = await _transactionService.CreateTransactionAsync(cancellationToken);

        var refreshToken = await _userRefreshTokenRepository.GetAll().SingleOrDefaultAsync(x => x.UserId == userId, cancellationToken);
        if (refreshToken != null)
            await _userRefreshTokenRepository.DeleteAsync(refreshToken, cancellationToken);

        await transaction.CommitAsync(cancellationToken);
    }

    public async Task<bool> CheckRefreshToken(CheckRefreshTokenRequest request, CancellationToken cancellationToken)
    {
        var userId = await _httpContextService.GetCurrentUserIdAsync();
        var refreshToken = await _userRefreshTokenRepository.GetAll().SingleOrDefaultAsync(x => x.UserId == userId, cancellationToken);

        if (refreshToken is null || refreshToken.Token != request.RefreshToken || refreshToken.ExpireDate <= DateTime.UtcNow)
            return false;

        return true;
    }

    private async Task AddRefreshToken(long userId, GenerateTokenResponse token, CancellationToken cancellationToken)
    {
        var userRefreshToken = await _userRefreshTokenRepository.GetAll().SingleOrDefaultAsync(x => x.UserId == userId, cancellationToken);

        if (userRefreshToken != null)
        {
            userRefreshToken.Token = token.RefreshToken;
            userRefreshToken.ExpireDate = token.RefreshTokenExpireDate;
            await _userRefreshTokenRepository.UpdateAsync(userRefreshToken, cancellationToken);
        }
        else
        {
            await _userRefreshTokenRepository.AddAsync(new UserRefreshToken()
            {
                Token = token.RefreshToken,
                ExpireDate = token.RefreshTokenExpireDate,
                UserId = userId
            }, cancellationToken);
        }
    }
}
