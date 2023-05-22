using MediatR;
using MYUPDZ.Application.Common.Bases;
using MYUPDZ.Application.Common.Behaviours;

namespace MYUPDZ.Application.Categories.Commands.Handlers.Add;

[Authorize(Policy = "ADD_CATEGORIE")]
public class AddCategorieCommand : IRequest<Response<string>>
{
    public string Designation { get; set; }

}
