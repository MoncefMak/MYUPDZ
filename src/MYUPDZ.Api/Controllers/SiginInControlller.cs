using Microsoft.AspNetCore.Mvc;
using MYUPDZ.Api.Base;
using MYUPDZ.Application.Common.Models;
using MYUPDZ.Application.Users.Querie.EventHandlerSiginIn;
using MYUPDZ.Domain.AppMetaData;

namespace MYUPDZ.Api.Controllers;

public class SiginInControlller : ApiControllerBase
{
    [HttpPost(Router.UserRoute.SignIn)]
    public async Task<ActionResult<Result>> SignIn([FromBody] SignInCommand command)
    {
        return await Mediator.Send(command);
    }

}
