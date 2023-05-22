using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MYUPDZ.Application.Common.Models;
using MYUPDZ.Infrastructure.Common.Option;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MYUPDZ.Infrastructure.Identity;

public class SignInServices : ISignInServices
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IConfiguration _configuration;
    private readonly JwtSettings _jwtSettings;
    private readonly JwtSecurityTokenHandler _tokenHandler;

    public SignInServices(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
        _jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();
        _tokenHandler = new JwtSecurityTokenHandler();
    }

    public async Task<(Result Result, string UserId, string Token)> LoginUserAsync(string userName, string password)
    {
        ApplicationUser user = await _userManager.FindByNameAsync(userName);
        if (user == null)
        {
            return (Result.Failure(new[] { "Invalid login attempt." }), null, null);
        }
        SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
        if (!result.Succeeded)
        {
            return (result.ToAppResult(), null, null);
        }
        string token = await GenerateToken(user.Id, user.Email);
        return (Result.Success(), user.Id, token);
    }

    public async Task<string> GenerateToken(string userId, string email)
    {
        ClaimsIdentity identity = GetClaimsIdentity(userId, email);
        SecurityTokenDescriptor tokenDescriptor = GetTokenDescriptor(identity);
        SecurityToken token = _tokenHandler.CreateToken(tokenDescriptor);
        string tokenString = _tokenHandler.WriteToken(token);
        ApplicationUser user = await _userManager.FindByIdAsync(userId);
        await _userManager.SetAuthenticationTokenAsync(user, "MYUPDZ", "Token", tokenString);
        return tokenString;
    }

    public ClaimsIdentity GetClaimsIdentity(string userId, string email)
    {
        List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Sub, userId)
            };

        return new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
    }

    public SecurityTokenDescriptor GetTokenDescriptor(ClaimsIdentity identity)
    {
        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SigningKey));
        return new SecurityTokenDescriptor
        {
            Subject = identity,
            Expires = DateTime.UtcNow.AddDays(1),
            Audience = _jwtSettings.Audiences[0],
            Issuer = _jwtSettings.Issuer,
            SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
        };
    }
}
