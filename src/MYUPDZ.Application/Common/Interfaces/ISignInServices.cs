using MYUPDZ.Application.Common.Models;

public interface ISignInServices
{
    Task<(Result Result, string UserId, string Token)> LoginUserAsync(string userName, string password);
    Task<string> GenerateToken(string userId, string email);
}
