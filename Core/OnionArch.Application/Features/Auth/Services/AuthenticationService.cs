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

    public AuthenticationService(
        IUserRepository userRepository,
        ITokenService tokenService,
        ICryptionService cryptionService,
        IUserRefreshTokenRepository userRefreshTokenRepository
        )
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
        _cryptionService = cryptionService;
        _userRefreshTokenRepository = userRefreshTokenRepository;
    }

    public async Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request)
    {
        UserLoginResponse response = new UserLoginResponse()
        {
            IsAuthenticated = false,
            AccessToken = "No Token",
            AccessTokenExpireDate = DateTime.Now
        };

        var user = await GetUser(request.Email);
        var plainPassword = await _cryptionService.Decrypt(request.EncryptedPassword);

        if (BCrypt.Net.BCrypt.Verify(plainPassword, user.Password)) //hatalı şifre girişi exception ile loglanır mı?
        {
            var generatedToken = await _tokenService.GenerateTokenAsync(new GenerateTokenRequest
            {
                UserId = user.Id.ToString(),
            });

            await CheckRefreshToken(user.Id, generatedToken.RefreshToken, generatedToken.RefreshTokenExpireDate);

            response.IsAuthenticated = true;
            response.AccessToken = generatedToken.AccessToken;
            response.AccessToken = generatedToken.AccessToken;
        }

        return response;
    }

    private async Task<User> GetUser(string email)
    {
        var user = await _userRepository.GetAll().SingleOrDefaultAsync(x => x.Email == email);
        if (user != null)
            return user;

        throw new UserNotFoundException("User not found.");
    }

    private async Task CheckRefreshToken(long userId, string refreshToken, DateTime refreshTokenExpireDate)
    {
        var userRefreshToken = await _userRefreshTokenRepository.GetAll().SingleOrDefaultAsync(x => x.UserId == userId);

        if (userRefreshToken != null)
        {
            userRefreshToken.Token = refreshToken;
            userRefreshToken.ExpireDate = refreshTokenExpireDate;
            await _userRefreshTokenRepository.UpdateAsync(userRefreshToken);
        }
        else
        {
            await _userRefreshTokenRepository.AddAsync(new UserRefreshToken()
            {
                Token = refreshToken,
                ExpireDate = refreshTokenExpireDate,
                UserId = userId
            });
        }
    }
}
