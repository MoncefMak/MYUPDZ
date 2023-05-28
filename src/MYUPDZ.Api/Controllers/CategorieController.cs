using Microsoft.AspNetCore.Mvc;
using MYUPDZ.Api.Base;
using MYUPDZ.Application.Categories.Commands.Handlers.Add;
using MYUPDZ.Application.Categories.Commands.Handlers.Archive;
using MYUPDZ.Application.Categories.Commands.Handlers.Edit;
using MYUPDZ.Application.Categories.Queries.EventHandlersList;
using MYUPDZ.Application.Categories.Queries.EventHandlersSingle;
using MYUPDZ.Application.Common.Models;
using MYUPDZ.Domain.AppMetaData;

namespace MYUPDZ.Api.Controllers;

public class CategorieController : ApiControllerBase
{
    [HttpGet(Router.CategorieRoute.List)]
    public async Task<List<CategorieDto>> GetCategorieList()
    {
        return await Mediator.Send(new GetCategorieListQuery());

    }

    [HttpGet(Router.CategorieRoute.GetById)]
    public async Task<CategorieDto> GetCategorieById([FromRoute] int id)
    {
        return await Mediator.Send(new GetCategorieSingleQuery(id));
    }

    [HttpPost(Router.CategorieRoute.Add)]
    public async Task<ActionResult<int>> CreateCategorieBy([FromBody] AddCategorieCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut(Router.CategorieRoute.Edit)]
    public async Task<ActionResult> EditCategorieBy([FromBody] EditCategorieCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete(Router.CategorieRoute.Archive)]
    public async Task<ActionResult> ArchiveCategorieBy([FromBody] ArchiveCategorieCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }

}
