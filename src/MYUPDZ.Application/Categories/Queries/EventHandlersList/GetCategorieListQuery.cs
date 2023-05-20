using MediatR;
using MYUPDZ.Application.Common.Bases;
using MYUPDZ.Application.Common.Models;

namespace MYUPDZ.Application.Categories.Queries.EventHandlersList;

public class GetCategorieListQuery : IRequest<Response<List<CategorieDto>>>
{

}
