using MediatR;
using MYUPDZ.Application.Common.Bases;

namespace MYUPDZ.Application.Categories.Commands.Handlers.Add;

public class AddCategorieCommand : IRequest<Response<string>>
{
    public string Designation { get; set; }

}
