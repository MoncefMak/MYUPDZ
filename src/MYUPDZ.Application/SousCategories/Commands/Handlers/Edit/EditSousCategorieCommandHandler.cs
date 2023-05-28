using MediatR;
using MYUPDZ.Application.Common.Interfaces.Repository;

namespace MYUPDZ.Application.SousCategories.Commands.Handlers.Edit;

public class EditSousCategorieCommandHandler : IRequestHandler<EditSousCategorieCommand, Unit>
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
    public async Task<Unit> Handle(EditSousCategorieCommand request, CancellationToken cancellationToken)
    {
        await _repositorySousCategorie.EditSousCategorieAsync(request.Id, request.Designation, request.CategorieId);
        return Unit.Value;
    }
    #endregion

}
