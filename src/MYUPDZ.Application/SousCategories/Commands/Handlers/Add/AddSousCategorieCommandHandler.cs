using MediatR;
using MYUPDZ.Application.Common.Interfaces.Repository;

namespace MYUPDZ.Application.SousCategories.Commands.Handlers.Add;

public class AddSousCategorieCommandHandler : IRequestHandler<AddSousCategorieCommand, int>
{
    #region Fildes
    private readonly IRepositorySousCategorie _repositorySousCategorie;
    #endregion

    #region Constructor
    public AddSousCategorieCommandHandler(IRepositorySousCategorie repositorySousCategorie)
    {
        _repositorySousCategorie = repositorySousCategorie;
    }
    #endregion


    #region Handel an Function
    public async Task<int> Handle(AddSousCategorieCommand request, CancellationToken cancellationToken)
    {
        var result = await _repositorySousCategorie.AddSousCategorieAsync(request.Designation, request.CategorieId);

        return result;
    }
    #endregion

}
