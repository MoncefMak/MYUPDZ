using MediatR;
using MYUPDZ.Application.Common.Bases;
using MYUPDZ.Application.Common.Behaviours;
using MYUPDZ.Application.Common.Models;

namespace MYUPDZ.Application.Categories.Queries.EventHandlersSingle;

[Authorize(Policy = "VIEW_CATEGORIE")]
public class GetCategorieSingleQuery : IRequest<Response<CategorieDto>>
{
    public int Id { get; set; }

    public GetCategorieSingleQuery(int id)
    {
        Id = id;
    }
}
