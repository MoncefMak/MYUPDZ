using MediatR;
using MYUPDZ.Application.Common.Interfaces.Repository;

namespace MYUPDZ.Application.Fonctionnaires.Commands.Handlers.Add;

public class AddFonctionnaireCommandHandler : IRequestHandler<AddFonctionnaireCommand, int>
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
    public async Task<int> Handle(AddFonctionnaireCommand request, CancellationToken cancellationToken)
    {
        var result = await _repositoryFonctionnaire.AddFonctionnaireAsync(request.Nom, request.Prenom, request.Email, request.Password, request.Matricule, request.DateEmbauche, request.Salaire);
        return result;
    }
    #endregion

}
