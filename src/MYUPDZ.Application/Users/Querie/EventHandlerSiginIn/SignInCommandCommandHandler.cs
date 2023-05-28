using MediatR;
using MYUPDZ.Application.Common.Models;

namespace MYUPDZ.Application.Users.Querie.EventHandlerSiginIn;

public class SignInCommandCommandHandler : IRequestHandler<SignInCommand, Result>
{
    #region Fildes
    private readonly ISignInServices _signInServices;
    #endregion

    #region Constructor
    public SignInCommandCommandHandler(ISignInServices signInServices)
    {
        _signInServices = signInServices;
    }
    #endregion


    #region Handel an Function
    public async Task<Result> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var result = await _signInServices.LoginUserAsync(request.UserName, request.Password);

        if (result.Result.Succeeded)
        {
            return Result.Success("Connexion Successfully", result.Token);
        }
        else if (result.Result.Errors != null && result.Result.Errors.Any())
        {
            return Result.Failure(result.Result.Errors);
        }
        return Result.Failure("Unknown error occurred.");
    }

    #endregion

}
