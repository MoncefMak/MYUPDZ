using MediatR;
using MYUPDZ.Application.Common.Bases;
using MYUPDZ.Application.Common.Interfaces.Repository;

namespace MYUPDZ.Application.Categories.Commands.Handlers.Edit;

public class EditCategorieCommandHandler : ResponseHandler, IRequestHandler<EditCategorieCommand, Response<string>>
{
    #region Fildes
    private readonly IRepositoryCategorie _repositoryCategorie;
    #endregion

    #region Constructor
    public EditCategorieCommandHandler(IRepositoryCategorie repositoryCategorie)
    {
        _repositoryCategorie = repositoryCategorie;
    }
    #endregion


    #region Handel an Function
    public async Task<Response<string>> Handle(EditCategorieCommand request, CancellationToken cancellationToken)
    {
        var categorie = await _repositoryCategorie.GetByIdAsync(request.Id);
        if (categorie == null) return NotFound<string>("Categorie not exist");
        var result = await _repositoryCategorie.EditCategorieAsync(request.Id, request.Designation);
        return Success("Created Successfully");
    }
    #endregion

}
