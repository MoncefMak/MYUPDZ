using MediatR;
using MYUPDZ.Application.Common.Behaviours;

namespace MYUPDZ.Application.SousCategories.Commands.Handlers.Add;

[Authorize(Policy = "ADD_SOUS_CATEGORIE")]
public class AddSousCategorieCommand : IRequest<int>
{
    public string Designation { get; set; }
    public int CategorieId { get; set; }
}
