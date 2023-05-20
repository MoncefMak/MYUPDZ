using MediatR;
using MYUPDZ.Application.Common.Bases;
using MYUPDZ.Application.Common.Models;

namespace MYUPDZ.Application.SousCategories.Queries.EventHandlersSingle;

public class GetSousCategorieSingleQuery : IRequest<Response<SousCategorieDto>>
{
    public int Id { get; set; }

    public GetSousCategorieSingleQuery(int id)
    {
        Id = id;
    }
}
