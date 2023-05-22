using MYUPDZ.Application.Common.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MYUPDZ.Api.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? UserId
    {
        get
        {
            string? token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].FirstOrDefault()
                ?.Split(" ").Last();
            if (token is null) return null;
            return GetUserIdFromToken(token);
        }
    }

    private static string GetUserIdFromToken(string token)
    {
        JwtSecurityTokenHandler handler = new();
        JwtSecurityToken? jwtToken = handler.ReadJwtToken(token);
        Claim? userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "sub");
        if (userIdClaim is null) throw new Exception("Token does not contain user ID.");
        return userIdClaim.Value;
    }
}