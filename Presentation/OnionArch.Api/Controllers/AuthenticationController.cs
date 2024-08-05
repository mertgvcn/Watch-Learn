using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnionArch.Application.Features.Auth.Models;
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
        var result = await _authenticationService.LoginUserAsync(request, _cancellationToken);

        return result;
    }
}
