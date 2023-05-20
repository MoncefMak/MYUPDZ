using MYUPDZ.Application.Common.Models;

public interface ISignInServices
{
    Task<(Result Result, string UserId)> LoginUserAsync(string userName, string password);
}
