using MYUPDZ.Application.Common.Models;

namespace MYUPDZ.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<string> GetUserNameAsync(string userId);

    Task<bool> IsInRoleAsync(string userId, string role);

    Task<bool> AuthorizeAsync(string userId, string policyName);

    Task<(Result Result, string UserId)> CreateUserAsync(string matricule, string email, string password);
    Task<(Result Result, string UserId)> UpdateUserAsync(string userId, string matricule, string email, string password);
    Task<bool> BlockUserAsync(string id);

    Task<Result> DeleteUserAsync(string userId);
}
