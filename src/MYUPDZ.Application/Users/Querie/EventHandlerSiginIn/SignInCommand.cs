using MediatR;
using MYUPDZ.Application.Common.Bases;

namespace MYUPDZ.Application.Users.Querie.EventHandlerSiginIn;

public class SignInCommand : IRequest<Response<string>>
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
