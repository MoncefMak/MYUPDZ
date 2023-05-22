using MediatR;
using MYUPDZ.Application.Common.Bases;
using MYUPDZ.Application.Common.Behaviours;

namespace MYUPDZ.Application.SousCategories.Commands.Handlers.Edit;

[Authorize(Policy = "UPDATE_SOUS_CATEGORIE")]
public class EditSousCategorieCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public string Designation { get; set; }
    public int CategorieId { get; set; }
}
