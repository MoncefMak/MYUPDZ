using Microsoft.AspNetCore.Mvc;
using MYUPDZ.Api.Base;
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
    public async Task<IActionResult> GetFonctionnaireList()
    {
        return NewResult(await Mediator.Send(new GetFonctionnaireListQuery()));

    }

    [HttpGet(Router.FonctionnaireRoute.GetById)]
    public async Task<IActionResult> GetFonctionnaireById([FromRoute] int id)
    {
        return NewResult(await Mediator.Send(new GetFonctionnaireSingleQuery(id)));
    }

    [HttpPost(Router.FonctionnaireRoute.Add)]
    public async Task<IActionResult> CreateFonctionnaireBy([FromBody] AddFonctionnaireCommand command)
    {
        return NewResult(await Mediator.Send(command));
    }

    [HttpPut(Router.FonctionnaireRoute.Edit)]
    public async Task<IActionResult> EditFonctionnaireBy([FromBody] EditFonctionnaireCommand command)
    {
        return NewResult(await Mediator.Send(command));
    }

    [HttpDelete(Router.FonctionnaireRoute.Archive)]
    public async Task<IActionResult> ArchiveFonctionnaireBy([FromBody] ArchiveFonctionnaireCommand command)
    {
        return NewResult(await Mediator.Send(command));
    }

}
