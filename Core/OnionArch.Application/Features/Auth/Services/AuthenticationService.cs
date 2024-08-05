using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Exceptions.Features.Auth;
using OnionArch.Application.Features.Auth.Models;
using OnionArch.Application.Interfaces.Repositories;
using OnionArch.Application.Interfaces.Services;
using OnionArch.Domain.Entities;
using OnionArch.Infrastructure.Token.Models;

namespace OnionArch.Application.Features.Auth.Services;
public sealed class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;
    private readonly ICryptionService _cryptionService;
    private readonly IUserRefreshTokenRepository _userRefreshTokenRepository;
    private readonly ITransactionService _transactionService;

    public AuthenticationService(
        IUserRepository userRepository,
        ITokenService tokenService,
        ICryptionService cryptionService,
        IUserRefreshTokenRepository userRefreshTokenRepository,
        ITransactionService transactionService
        )
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
        _cryptionService = cryptionService;
        _userRefreshTokenRepository = userRefreshTokenRepository;
        _transactionService = transactionService;
    }

    public async Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request, CancellationToken cancellationToken)
    {
        using var transaction = await _transactionService.CreateTransactionAsync(cancellationToken);

        UserLoginResponse response = new UserLoginResponse()
        {
            IsAuthenticated = false,
            AccessToken = "No Token",
            AccessTokenExpireDate = DateTime.Now
        };

        var user = await GetUser(request.Email, cancellationToken);
        //var plainPassword = await _cryptionService.Decrypt(request.EncryptedPassword);

        //if (BCrypt.Net.BCrypt.Verify(request.EncryptedPassword, user.Password)) //hatalı şifre girişi exception ile loglanır mı?, request.EncrpytedPassword => plainPassword olacak
        if (request.EncryptedPassword == user.Password)
        {
            var generatedToken = await _tokenService.GenerateTokenAsync(new GenerateTokenRequest
            {
                UserId = user.Id,
                Role = user.Role
            }, cancellationToken);

            await CheckRefreshToken(user.Id, generatedToken, cancellationToken);

            response.IsAuthenticated = true;
            response.AccessToken = generatedToken.AccessToken;
            response.AccessToken = generatedToken.AccessToken;
        }

        await transaction.CommitAsync(cancellationToken);
        return response;
    }

    private async Task<User> GetUser(string email, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAll().SingleOrDefaultAsync(x => x.Email == email, cancellationToken);
        if (user != null)
            return user;

        throw new UserNotFoundException("User not found.");
    }

    private async Task CheckRefreshToken(long userId, GenerateTokenResponse token, CancellationToken cancellationToken)
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

    private async Task<GenerateTokenResponse> CreateTokenByRefreshToken(string refreshToken)
    {

    }
}
