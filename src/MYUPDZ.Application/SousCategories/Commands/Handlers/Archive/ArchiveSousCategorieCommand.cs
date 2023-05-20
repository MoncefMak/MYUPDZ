using MediatR;
using MYUPDZ.Application.Common.Bases;

namespace MYUPDZ.Application.SousCategories.Commands.Handlers.Archive;

public class ArchiveSousCategorieCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
}
