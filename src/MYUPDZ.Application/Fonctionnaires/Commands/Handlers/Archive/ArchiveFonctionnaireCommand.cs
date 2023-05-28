using MediatR;
using MYUPDZ.Application.Common.Behaviours;

namespace MYUPDZ.Application.Fonctionnaires.Commands.Handlers.Archive;

[Authorize(Policy = "ARCHIVE _FONCTIONNAIRE")]
public class ArchiveFonctionnaireCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
