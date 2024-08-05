using Microsoft.AspNetCore.Http;
using OnionArch.Application.Interfaces.Services;
using System.Security.Claims;

namespace OnionArch.Infrastructure.HttpContext;

public class HttpContextService : IHttpContextService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ICryptionService _cryptionService;

    public HttpContextService(IHttpContextAccessor httpContextAccessor, ICryptionService cryptionService)
    {
        _httpContextAccessor = httpContextAccessor;
        _cryptionService = cryptionService;
    }

    public async Task<long> GetCurrentUserIdAsync()
    {
        if (_httpContextAccessor.HttpContext is not null)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId != null)
                return long.Parse(await _cryptionService.Decrypt(userId));
        }

        return -1;
    }
}

