using MediatR;
using MYUPDZ.Application.Common.Bases;
using MYUPDZ.Application.Common.Interfaces.Repository;

namespace MYUPDZ.Application.SousCategories.Commands.Handlers.Edit;

public class EditSousCategorieCommandHandler : ResponseHandler, IRequestHandler<EditSousCategorieCommand, Response<string>>
{
    #region Fildes
    private readonly IRepositorySousCategorie _repositorySousCategorie;
    #endregion

    #region Constructor
    public EditSousCategorieCommandHandler(IRepositorySousCategorie repositorySousCategorie)
    {
        _repositorySousCategorie = repositorySousCategorie;
    }
    #endregion


    #region Handel an Function
    public async Task<Response<string>> Handle(EditSousCategorieCommand request, CancellationToken cancellationToken)
    {
        var categorie = await _repositorySousCategorie.GetByIdAsync(request.Id);
        if (categorie == null) return NotFound<string>("Sous Categorie not exist");
        var result = await _repositorySousCategorie.EditSousCategorieAsync(request.Id, request.Designation, request.CategorieId);
        return Success("Update Successfully");
    }
    #endregion

}
