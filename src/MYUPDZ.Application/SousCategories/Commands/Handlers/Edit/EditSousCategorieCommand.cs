using MediatR;
using MYUPDZ.Application.Common.Bases;

namespace MYUPDZ.Application.SousCategories.Commands.Handlers.Edit;

public class EditSousCategorieCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public string Designation { get; set; }
    public int CategorieId { get; set; }
}
