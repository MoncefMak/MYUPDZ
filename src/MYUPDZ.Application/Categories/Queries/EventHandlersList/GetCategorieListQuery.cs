using MediatR;
using MYUPDZ.Application.Common.Bases;
using MYUPDZ.Application.Common.Behaviours;
using MYUPDZ.Application.Common.Models;

namespace MYUPDZ.Application.Categories.Queries.EventHandlersList;

[Authorize(Policy = "VIEW_CATEGORIE")]
public class GetCategorieListQuery : IRequest<Response<List<CategorieDto>>>
{

}
