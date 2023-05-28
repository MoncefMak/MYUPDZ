using MediatR;
using MYUPDZ.Application.Common.Behaviours;
using MYUPDZ.Application.Common.Models;

namespace MYUPDZ.Application.Fonctionnaires.Queries.EventHandlersSingle;

[Authorize(Policy = "VIEW_FONCTIONNAIRE")]
public class GetFonctionnaireSingleQuery : IRequest<FonctionnaireDto>
{
    public int Id { get; set; }

    public GetFonctionnaireSingleQuery(int id)
    {
        Id = id;
    }
}
