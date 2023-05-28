using MediatR;
using MYUPDZ.Application.Common.Behaviours;
using MYUPDZ.Application.Common.Models;

namespace MYUPDZ.Application.SousCategories.Queries.EventHandlersSingle;

[Authorize(Policy = "VIEW_SOUS_CATEGORIE")]
public class GetSousCategorieSingleQuery : IRequest<SousCategorieDto>
{
    public int Id { get; set; }

    public GetSousCategorieSingleQuery(int id)
    {
        Id = id;
    }
}
