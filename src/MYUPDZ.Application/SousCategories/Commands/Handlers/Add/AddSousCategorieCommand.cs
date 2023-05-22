using MediatR;
using MYUPDZ.Application.Common.Bases;
using MYUPDZ.Application.Common.Behaviours;

namespace MYUPDZ.Application.SousCategories.Commands.Handlers.Add;

[Authorize(Policy = "ADD_SOUS_CATEGORIE")]
public class AddSousCategorieCommand : IRequest<Response<string>>
{
    public string Designation { get; set; }
    public int CategorieId { get; set; }
}
