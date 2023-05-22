using MediatR;
using MYUPDZ.Application.Common.Bases;
using MYUPDZ.Application.Common.Behaviours;

namespace MYUPDZ.Application.Categories.Commands.Handlers.Edit;

[Authorize(Policy = "UPDATE_CATEGORIE")]
public class EditCategorieCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public string Designation { get; set; }

}
