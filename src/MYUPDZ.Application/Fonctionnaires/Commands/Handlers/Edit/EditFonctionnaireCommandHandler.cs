using MediatR;
using MYUPDZ.Application.Common.Interfaces.Repository;

namespace MYUPDZ.Application.Fonctionnaires.Commands.Handlers.Edit;

public class EditFonctionnaireCommandHandler : IRequestHandler<EditFonctionnaireCommand, Unit>
{
    #region Fildes
    private readonly IRepositoryFonctionnaire _repositoryFonctionnaire;
    #endregion

    #region Constructor
    public EditFonctionnaireCommandHandler(IRepositoryFonctionnaire repositoryFonctionnaire)
    {
        _repositoryFonctionnaire = repositoryFonctionnaire;
    }
    #endregion


    #region Handel an Function
    public async Task<Unit> Handle(EditFonctionnaireCommand request, CancellationToken cancellationToken)
    {
        await _repositoryFonctionnaire.EditFonctionnaireAsync(request.Id, request.Nom, request.Prenom, request.Email, request.Password, request.Matricule, request.DateEmbauche, request.Salaire);
        return Unit.Value;
    }
    #endregion

}
