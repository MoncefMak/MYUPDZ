using Microsoft.AspNetCore.Mvc;
using MYUPDZ.Api.Base;
using MYUPDZ.Application.Categories.Commands.Handlers.Add;
using MYUPDZ.Application.Categories.Commands.Handlers.Archive;
using MYUPDZ.Application.Categories.Commands.Handlers.Edit;
using MYUPDZ.Application.Categories.Queries.EventHandlersList;
using MYUPDZ.Application.Categories.Queries.EventHandlersSingle;
using MYUPDZ.Domain.AppMetaData;

namespace MYUPDZ.Api.Controllers;

[ApiController]
public class CategorieController : ApiControllerBase
{

    [HttpGet(Router.CategorieRoute.List)]
    public async Task<IActionResult> GetCategorieList()
    {
        return NewResult(await Mediator.Send(new GetCategorieListQuery()));

    }

    [HttpGet(Router.CategorieRoute.GetById)]
    public async Task<IActionResult> GetCategorieById([FromRoute] int id)
    {
        return NewResult(await Mediator.Send(new GetCategorieSingleQuery(id)));
    }

    [HttpPost(Router.CategorieRoute.Create)]
    public async Task<IActionResult> CreateCategorieBy([FromBody] AddCategorieCommand command)
    {
        return NewResult(await Mediator.Send(command));
    }

    [HttpPut(Router.CategorieRoute.Edit)]
    public async Task<IActionResult> EditCategorieBy([FromBody] EditCategorieCommand command)
    {
        return NewResult(await Mediator.Send(command));
    }

    [HttpDelete(Router.CategorieRoute.Archive)]
    public async Task<IActionResult> ArchiveCategorieBy([FromBody] ArchiveCategorieCommand command)
    {
        return NewResult(await Mediator.Send(command));
    }


}
