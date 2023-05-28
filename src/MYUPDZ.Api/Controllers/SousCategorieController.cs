using MediatR;
using Microsoft.AspNetCore.Mvc;
using MYUPDZ.Api.Base;
using MYUPDZ.Application.Common.Models;
using MYUPDZ.Application.SousCategories.Commands.Handlers.Add;
using MYUPDZ.Application.SousCategories.Commands.Handlers.Archive;
using MYUPDZ.Application.SousCategories.Commands.Handlers.Edit;
using MYUPDZ.Application.SousCategories.Queries.EventHandlers;
using MYUPDZ.Application.SousCategories.Queries.EventHandlersSingle;
using MYUPDZ.Domain.AppMetaData;

namespace MYUPDZ.Api.Controllers
{
    public class SousCategorieController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public SousCategorieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Router.SousCategorieRoute.List)]
        public async Task<List<SousCategorieDto>> GetCategorieList()
        {
            return await Mediator.Send(new GetSousCategoriesListQuery());
        }

        [HttpGet(Router.SousCategorieRoute.GetById)]
        public async Task<SousCategorieDto> GetCategorieById([FromRoute] int id)
        {
            return await Mediator.Send(new GetSousCategorieSingleQuery(id));
        }

        [HttpPost(Router.SousCategorieRoute.Add)]
        public async Task<ActionResult<int>> CreateSousCategorieBy([FromBody] AddSousCategorieCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut(Router.SousCategorieRoute.Edit)]
        public async Task<ActionResult> EditCategorieBy([FromBody] EditSousCategorieCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete(Router.SousCategorieRoute.Archive)]
        public async Task<ActionResult> ArchiveCategorieBy([FromBody] ArchiveSousCategorieCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

    }

}
