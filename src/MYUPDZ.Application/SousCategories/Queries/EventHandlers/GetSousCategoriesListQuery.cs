using MediatR;
using MYUPDZ.Application.Common.Bases;
using MYUPDZ.Application.Common.Behaviours;
using MYUPDZ.Application.Common.Models;

namespace MYUPDZ.Application.SousCategories.Queries.EventHandlers;

[Authorize(Policy = "VIEW_SOUS_CATEGORIE")]
public class GetSousCategoriesListQuery : IRequest<Response<List<SousCategorieDto>>>
{

}
