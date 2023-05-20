using MediatR;
using MYUPDZ.Application.Common.Bases;

namespace MYUPDZ.Application.Fonctionnaires.Commands.Handlers.Archive;

public class ArchiveFonctionnaireCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
}
