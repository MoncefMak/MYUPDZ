using MediatR;
using MYUPDZ.Application.Common.Models;

namespace MYUPDZ.Application.Users.Querie.EventHandlerSiginIn;

public class SignInCommand : IRequest<Result>
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
