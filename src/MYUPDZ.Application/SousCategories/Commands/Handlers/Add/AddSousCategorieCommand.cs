using MediatR;
using MYUPDZ.Application.Common.Bases;

namespace MYUPDZ.Application.SousCategories.Commands.Handlers.Add;

public class AddSousCategorieCommand : IRequest<Response<string>>
{
    public string Designation { get; set; }
    public int CategorieId { get; set; }
}
