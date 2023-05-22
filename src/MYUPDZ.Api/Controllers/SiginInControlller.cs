using Microsoft.AspNetCore.Mvc;
using MYUPDZ.Api.Base;
using MYUPDZ.Application.Users.Querie.EventHandlerSiginIn;
using MYUPDZ.Domain.AppMetaData;

namespace MYUPDZ.Api.Controllers;

public class SiginInControlller : ApiControllerBase
{
    [HttpPost(Router.UserRoute.SignIn)]
    public async Task<IActionResult> SignIn([FromBody] SignInCommand command)
    {
        return NewResult(await Mediator.Send(command));
    }

}
