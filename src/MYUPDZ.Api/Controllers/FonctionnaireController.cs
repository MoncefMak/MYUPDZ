using Microsoft.AspNetCore.Mvc;
using MYUPDZ.Api.Base;
using MYUPDZ.Application.Common.Models;
using MYUPDZ.Application.Fonctionnaires.Commands.Handlers.Add;
using MYUPDZ.Application.Fonctionnaires.Commands.Handlers.Archive;
using MYUPDZ.Application.Fonctionnaires.Commands.Handlers.Edit;
using MYUPDZ.Application.Fonctionnaires.Queries.EventHandlersList;
using MYUPDZ.Application.Fonctionnaires.Queries.EventHandlersSingle;
using MYUPDZ.Domain.AppMetaData;

namespace MYUPDZ.Api.Controllers;


public class Fonctionnaire : ApiControllerBase
{

    [HttpGet(Router.FonctionnaireRoute.List)]
    public async Task<List<FonctionnaireDto>> GetFonctionnaireList()
    {
        return await Mediator.Send(new GetFonctionnaireListQuery());

    }

    [HttpGet(Router.FonctionnaireRoute.GetById)]
    public async Task<FonctionnaireDto> GetFonctionnaireById([FromRoute] int id)
    {
        return await Mediator.Send(new GetFonctionnaireSingleQuery(id));
    }

    [HttpPost(Router.FonctionnaireRoute.Add)]
    public async Task<ActionResult<int>> CreateFonctionnaireBy([FromBody] AddFonctionnaireCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut(Router.FonctionnaireRoute.Edit)]
    public async Task<ActionResult> EditFonctionnaireBy([FromBody] EditFonctionnaireCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete(Router.FonctionnaireRoute.Archive)]
    public async Task<ActionResult> ArchiveFonctionnaireBy([FromBody] ArchiveFonctionnaireCommand command)
    {
        await Mediator.Send(command);
        return NoContent();
    }

}
