using MediatR;
using MYUPDZ.Application.Common.Bases;
using MYUPDZ.Application.Common.Models;

namespace MYUPDZ.Application.SousCategories.Queries.EventHandlers;

public class GetSousCategoriesListQuery : IRequest<Response<List<SousCategorieDto>>>
{

}
