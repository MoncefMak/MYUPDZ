using MediatR;
using MYUPDZ.Application.Common.Bases;
using MYUPDZ.Application.Common.Interfaces.Repository;

namespace MYUPDZ.Application.Fonctionnaires.Commands.Handlers.Archive;

public class ArchiveFonctionnaireCommandHandler : ResponseHandler, IRequestHandler<ArchiveFonctionnaireCommand, Response<string>>
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
    public async Task<Response<string>> Handle(ArchiveFonctionnaireCommand request, CancellationToken cancellationToken)
    {
        var result = await _repositoryFonctionnaire.ArchiveFonctionnaireAsync(request.Id);
        return Success("Archived Successfully");
    }
    #endregion

}
