using MediatR;
using MYUPDZ.Application.Common.Bases;

namespace MYUPDZ.Application.Users.Querie.EventHandlerSiginIn;

public class SignInCommandCommandHandler : ResponseHandler, IRequestHandler<SignInCommand, Response<string>>
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
    public async Task<Response<string>> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var result = await _signInServices.LoginUserAsync(request.UserName, request.Password);
        if (result.Result.Succeeded)
        {
            return Login("Connexion Successfully", result.Token);
        }
        else if (result.Result.Errors != null && result.Result.Errors.Any())
        {
            return UnprocessableUser<string>(result.Result);
        }
        else
        {
            return BadRequest<string>();
        }
    }



    #endregion

}
