using MediatR;
using MYUPDZ.Application.Common.Bases;
using MYUPDZ.Application.Common.Interfaces.Repository;

namespace MYUPDZ.Application.Fonctionnaires.Commands.Handlers.Add;

public class AddFonctionnaireCommandHandler : ResponseHandler, IRequestHandler<AddFonctionnaireCommand, Response<string>>
{
    #region Fildes
    private readonly IRepositoryFonctionnaire _repositoryFonctionnaire;
    #endregion

    #region Constructor
    public AddFonctionnaireCommandHandler(IRepositoryFonctionnaire repositoryFonctionnaire)
    {
        _repositoryFonctionnaire = repositoryFonctionnaire;
    }
    #endregion


    #region Handel an Function
    public async Task<Response<string>> Handle(AddFonctionnaireCommand request, CancellationToken cancellationToken)
    {
        var result = await _repositoryFonctionnaire.AddFonctionnaireAsync(request.Nom, request.Prenom, request.Email, request.Password, request.Matricule, request.DateEmbauche, request.Salaire);
        if (!result) return UnprocessableEntity<string>("Fonctionnaire With this Matricule or Mail exist");
        else if (result) return Created("Fonctionnaire Add Sussessfully");
        return BadRequest<string>();
    }
    #endregion

}
