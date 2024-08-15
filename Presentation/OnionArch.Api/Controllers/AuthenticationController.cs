using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnionArch.Application.Exceptions.Auth;
using OnionArch.Application.Features.Auth.Models;
using OnionArch.Application.InfrastructureModels.Models;
using OnionArch.Application.Interfaces.Services;

namespace OnionArch.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
	private readonly IAuthenticationService _authenticationService;
	private readonly CancellationToken _cancellationToken;

	public AuthenticationController(IAuthenticationService authenticationService, ICancellationTokenService cancellationTokenService)
	{
		_authenticationService = authenticationService;
		_cancellationToken = cancellationTokenService.cancellationToken;
	}

	[HttpPost]
	[AllowAnonymous]
	public async Task<ActionResult<UserLoginResponse>> Login([FromBody] UserLoginRequest request)
	{
		try
		{
			return Ok(await _authenticationService.LoginUserAsync(request, _cancellationToken));
		}
		catch (Exception ex)
		{
			if (ex is UnauthorizedAccessException)
				return Unauthorized();
			else
				throw;
		}
	}

	[HttpPost]
	[AllowAnonymous]
	public async Task<ActionResult> Register([FromBody] UserRegisterRequest request)
	{
		try
		{
			await _authenticationService.RegisterStudentAsync(request, _cancellationToken);
			return Ok();
		}
		catch (Exception ex)
		{
			if (ex is UserAlreadyExistsException)
				return Conflict();
			else
				throw;
		}
	}

	[HttpPost]
	[AllowAnonymous]
	public async Task<ActionResult<GenerateTokenResponse>> CreateAccessTokenByRefreshToken([FromBody] CreateAccessTokenByRefreshTokenRequest request)
	{
		try
		{
			return Ok(await _authenticationService.CreateAccessTokenByRefreshTokenAsync(request, _cancellationToken));
		}
		catch (RefreshTokenNotFoundException)
		{
			return NotFound();
		}
		catch (UnauthorizedAccessException)
		{
			return Unauthorized();
		}
	}

	[HttpPost]
	[AllowAnonymous]
	public async Task<ActionResult> CheckRefreshToken([FromBody] CheckRefreshTokenRequest request)
	{
		try
		{
			await _authenticationService.CheckRefreshToken(request, _cancellationToken);
			return Ok();
		}
		catch (Exception _)
		{
			return Problem(statusCode: 406);
		}
	}

	[HttpDelete]
	[Authorize]
	public async Task<ActionResult> RevokeRefreshToken()
	{
		await _authenticationService.RevokeRefreshTokenAsync(_cancellationToken);
		return Ok();
	}
}
