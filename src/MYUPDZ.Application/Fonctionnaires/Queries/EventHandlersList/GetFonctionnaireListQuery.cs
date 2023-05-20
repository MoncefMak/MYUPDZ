using MediatR;
using MYUPDZ.Application.Common.Bases;
using MYUPDZ.Application.Common.Models;

namespace MYUPDZ.Application.Fonctionnaires.Queries.EventHandlersList;

public class GetFonctionnaireListQuery : IRequest<Response<List<FonctionnaireDto>>>
{

}
