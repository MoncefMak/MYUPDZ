using MediatR;
using MYUPDZ.Application.Common.Bases;
using MYUPDZ.Application.Common.Interfaces.Repository;

namespace MYUPDZ.Application.Fonctionnaires.Commands.Handlers.Edit;

public class EditFonctionnaireCommandHandler : ResponseHandler, IRequestHandler<EditFonctionnaireCommand, Response<string>>
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
    public async Task<Response<string>> Handle(EditFonctionnaireCommand request, CancellationToken cancellationToken)
    {
        var fonctionnaire = await _repositoryFonctionnaire.GetByIdAsync(request.id);
        if (fonctionnaire == null) return NotFound<string>("fonctionnaire not exist");
        var result = await _repositoryFonctionnaire.EditFonctionnaireAsync(request.id, request.Nom, request.Prenom, request.Email, request.Password, request.Matricule, request.DateEmbauche, request.Salaire);
        return Success("Update Successfully");
    }
    #endregion

}
