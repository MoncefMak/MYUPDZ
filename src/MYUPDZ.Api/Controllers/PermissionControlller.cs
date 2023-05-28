using Microsoft.AspNetCore.Mvc;
using MYUPDZ.Api.Base;
using MYUPDZ.Application.Common.Models;
using MYUPDZ.Application.Permissions.Commands.Handlers.Add;
using MYUPDZ.Application.Permissions.Commands.Handlers.Delete;
using MYUPDZ.Domain.AppMetaData;

namespace MYUPDZ.Api.Controllers;

public class PermissionControlller : ApiControllerBase
{
    [HttpPost(Router.PermissionRoute.Add)]
    public async Task<ActionResult<Result>> AddPermisson([FromBody] AddPermissionCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpDelete(Router.PermissionRoute.Delete)]
    public async Task<ActionResult<Result>> DeletePermisson([FromBody] DeletePermissionCommand command)
    {
        return await Mediator.Send(command);
    }

}
