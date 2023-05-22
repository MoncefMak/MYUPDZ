using MediatR;
using Microsoft.AspNetCore.Mvc;
using MYUPDZ.Api.Base;
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
        public async Task<IActionResult> GetCategorieList()
        {
            return NewResult(await Mediator.Send(new GetSousCategoriesListQuery()));
        }

        [HttpGet(Router.SousCategorieRoute.GetById)]
        public async Task<IActionResult> GetCategorieById([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new GetSousCategorieSingleQuery(id)));
        }

        [HttpPost(Router.SousCategorieRoute.Add)]
        public async Task<IActionResult> CreateSousCategorieBy([FromBody] AddSousCategorieCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }

        [HttpPut(Router.SousCategorieRoute.Edit)]
        public async Task<IActionResult> EditCategorieBy([FromBody] EditSousCategorieCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }

        [HttpDelete(Router.SousCategorieRoute.Archive)]
        public async Task<IActionResult> ArchiveCategorieBy([FromBody] ArchiveSousCategorieCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
    }

}
