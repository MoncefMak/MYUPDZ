using MediatR;
using MYUPDZ.Application.Common.Behaviours;

namespace MYUPDZ.Application.Categories.Commands.Handlers.Edit;

[Authorize(Policy = "UPDATE_CATEGORIE")]
public class EditCategorieCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Designation { get; set; }
}
