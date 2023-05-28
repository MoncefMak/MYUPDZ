using MediatR;
using MYUPDZ.Application.Common.Interfaces.Repository;

namespace MYUPDZ.Application.Fonctionnaires.Commands.Handlers.Archive;

public class ArchiveFonctionnaireCommandHandler : IRequestHandler<ArchiveFonctionnaireCommand, Unit>
{
    #region Fildes
    private readonly IRepositoryFonctionnaire _repositoryFonctionnaire;
    #endregion

    #region Constructor
    public ArchiveFonctionnaireCommandHandler(IRepositoryFonctionnaire repositoryFonctionnaire)
    {
        _repositoryFonctionnaire = repositoryFonctionnaire;
    }
    #endregion


    #region Handel an Function
    public async Task<Unit> Handle(ArchiveFonctionnaireCommand request, CancellationToken cancellationToken)
    {
        await _repositoryFonctionnaire.ArchiveFonctionnaireAsync(request.Id);
        return Unit.Value;
    }
    #endregion

}
