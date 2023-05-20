using MediatR;
using MYUPDZ.Application.Common.Bases;

namespace MYUPDZ.Application.Categories.Commands.Handlers.Archive;

public class ArchiveCategorieCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
}
