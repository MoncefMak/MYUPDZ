using Microsoft.AspNetCore.Identity;
using MYUPDZ.Application.Common.Models;

namespace MYUPDZ.Infrastructure.Identity;

public class SignInServices : ISignInServices
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public SignInServices(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<(Result Result, string UserId)> LoginUserAsync(string userName, string password)
    {
        ApplicationUser? user = await _userManager.FindByEmailAsync(userName);
        if (user == null)
        {
            return (Result.Failure(new[] { "Invalid login attempt." }), null);
        }
        SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
        if (!result.Succeeded)
        {
            return (Result.Failure(new[] { "Invalid login attempt." }), null);
        }
        return (Result.Success(), user.Id);
    }
}
