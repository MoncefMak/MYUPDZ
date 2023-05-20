using MediatR;
using MYUPDZ.Application.Common.Bases;

namespace MYUPDZ.Application.Categories.Commands.Handlers.Edit;

public class EditCategorieCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public string Designation { get; set; }

}
