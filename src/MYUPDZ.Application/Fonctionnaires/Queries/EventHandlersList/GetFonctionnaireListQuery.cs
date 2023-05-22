using MediatR;
using MYUPDZ.Application.Common.Bases;
using MYUPDZ.Application.Common.Behaviours;
using MYUPDZ.Application.Common.Models;

namespace MYUPDZ.Application.Fonctionnaires.Queries.EventHandlersList;

[Authorize(Policy = "VIEW_FONCTIONNAIRE")]
public class GetFonctionnaireListQuery : IRequest<Response<List<FonctionnaireDto>>>
{

}
