using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MYUPDZ.Application.Common.Interfaces;
using MYUPDZ.Application.Common.Models;

namespace MYUPDZ.Infrastructure.Identity;

public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
    private readonly IAuthorizationService _authorizationService;

    public IdentityService(UserManager<ApplicationUser> userManager, IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory, IAuthorizationService authorizationService)
    {
        _userManager = userManager;
        _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        _authorizationService = authorizationService;
    }

    public async Task<string> GetUserNameAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        return user.UserName;
    }


    public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string email, string password)
    {
        var user = new ApplicationUser
        {
            UserName = userName,
            Email = email,
        };

        var result = await _userManager.CreateAsync(user, password);

        return (result.ToApplicationResult(), user.Id);
    }

    public async Task<(Result Result, string UserId)> UpdateUserAsync(string userId, string newUserName, string newEmail, string password)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return (Result.Failure("User not found."), null);
        }

        user.UserName = newUserName;
        user.Email = newEmail;

        var result = await _userManager.UpdateAsync(user);

        if (!result.Succeeded)
        {
            return (result.ToApplicationResult(), null);
        }

        if (!string.IsNullOrEmpty(password))
        {
            var passwordResult = await _userManager.RemovePasswordAsync(user);
            if (passwordResult.Succeeded)
            {
                var setPasswordResult = await _userManager.AddPasswordAsync(user, password);
                if (!setPasswordResult.Succeeded)
                {
                    return (setPasswordResult.ToApplicationResult(), null);
                }
            }
            else
            {
                return (passwordResult.ToApplicationResult(), null);
            }
        }

        return (Result.Success(), user.Id);
    }

    public async Task<bool> IsInRoleAsync(string userId, string role)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null && await _userManager.IsInRoleAsync(user, role);
    }

    public async Task<bool> AuthorizeAsync(string userId, string policyName)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        if (user == null)
        {
            return false;
        }

        var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

        var result = await _authorizationService.AuthorizeAsync(principal, policyName);

        return result.Succeeded;
    }

    public async Task<bool> BlockUserAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user != null)
        {
            user.LockoutEnabled = true;
            user.LockoutEnd = DateTimeOffset.MaxValue;
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }
        return false;
    }

    public async Task<Result> DeleteUserAsync(string userId)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null ? await DeleteUserAsync(user) : Result.Success();
    }

    public async Task<Result> DeleteUserAsync(ApplicationUser user)
    {
        var result = await _userManager.DeleteAsync(user);

        return result.ToApplicationResult();
    }
}
