using MediatR;
using MYUPDZ.Application.Common.Behaviours;

namespace MYUPDZ.Application.Categories.Commands.Handlers.Add;

[Authorize(Policy = "ADD_CATEGORIE")]
public class AddCategorieCommand : IRequest<int>
{
    public string Designation { get; set; }
}
