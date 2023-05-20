using Microsoft.AspNetCore.Identity;
using MYUPDZ.Application.Common.Models;

public static class SignInResultExtensions
{
    public static Result ToAppResult(this SignInResult result)
    {
        if (result.Succeeded)
        {
            return Result.Success();
        }

        List<string> errors = new();

        if (result.IsLockedOut)
        {
            errors.Add("User account is locked out.");
        }

        if (result.IsNotAllowed)
        {
            errors.Add("User is not allowed to sign in.");
        }

        if (result.RequiresTwoFactor)
        {
            errors.Add("User account requires two-factor authentication.");
        }

        if (errors.Count == 0)
        {
            errors.Add("Invalid login attempt.");
        }

        return Result.Failure(errors);
    }
}