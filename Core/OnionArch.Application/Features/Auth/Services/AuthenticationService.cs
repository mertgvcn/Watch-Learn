﻿using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Features.Auth.Models;
using OnionArch.Application.Interfaces.Repositories;
using OnionArch.Application.Interfaces.Services;
using OnionArch.Domain.Entities;
using OnionArch.Infrastructure.Token.Models;
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

    public AuthenticationService(
        IUserService userService,
        ITokenService tokenService,
        ICryptionService cryptionService,
        IUserRefreshTokenRepository userRefreshTokenRepository,
        ITransactionService transactionService,
        IHttpContextService httpContextService
        )
    {
        _userService = userService;
        _tokenService = tokenService;
        _cryptionService = cryptionService;
        _userRefreshTokenRepository = userRefreshTokenRepository;
        _transactionService = transactionService;
        _httpContextService = httpContextService;
    }

    public async Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request, CancellationToken cancellationToken)
    {
        using var transaction = await _transactionService.CreateTransactionAsync(cancellationToken);

        UserLoginResponse response = new UserLoginResponse()
        {
            IsAuthenticated = false,
            AccessToken = null,
            AccessTokenExpireDate = null,
            RefreshToken = null
        };

        var user = await _userService.GetUserByEmailAsync(request.Email, cancellationToken);
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
            response.AccessTokenExpireDate = generatedToken.AccessTokenExpireDate;
            response.RefreshToken = generatedToken.RefreshToken;
        }

        await transaction.CommitAsync(cancellationToken);
        return response;
    }

    public async Task<GenerateTokenResponse> CreateAccessTokenByRefreshTokenAsync(CreateAccessTokenByRefreshTokenRequest request, CancellationToken cancellationToken)
    {
        var principal = _tokenService.GetPrincipalFromExpiredAccessToken(request.AccessToken);

        if (principal?.FindFirstValue(ClaimTypes.NameIdentifier) is null)
            throw new UnauthorizedAccessException();

        var userId = long.Parse(await _cryptionService.Decrypt(principal.FindFirstValue(ClaimTypes.NameIdentifier)!));

        using var transaction = await _transactionService.CreateTransactionAsync(cancellationToken);

        //bu kısım user service e eklenecek bir method ile tek satırda yapılabilir.
        var user = await _userService.GetUserByIdAsync(userId, cancellationToken);
        var refreshToken = await _userRefreshTokenRepository.GetAll().SingleOrDefaultAsync(x => x.UserId == userId, cancellationToken);

        if (user is null || refreshToken is null || refreshToken.Token != request.RefreshToken || refreshToken.ExpireDate < DateTime.UtcNow)
            throw new UnauthorizedAccessException();

        var token = await _tokenService.GenerateTokenAsync(new GenerateTokenRequest
        {
            UserId = userId,
            Role = user.Role
        }, cancellationToken);

        await transaction.CommitAsync(cancellationToken);

        return new GenerateTokenResponse
        {
            AccessToken = token.AccessToken,
            AccessTokenExpireDate = token.AccessTokenExpireDate,
            RefreshToken = request.RefreshToken
        };
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
}
