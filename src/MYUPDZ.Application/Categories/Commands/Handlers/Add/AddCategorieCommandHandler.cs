using MediatR;
using MYUPDZ.Application.Common.Interfaces.Repository;

namespace MYUPDZ.Application.Categories.Commands.Handlers.Add;

public class AddCategorieCommandHandler : IRequestHandler<AddCategorieCommand, int>
{
    #region Fildes
    private readonly IRepositoryCategorie _repositoryCategorie;
    #endregion

    #region Constructor
    public AddCategorieCommandHandler(IRepositoryCategorie repositoryCategorie)
    {
        _repositoryCategorie = repositoryCategorie;
    }
    #endregion


    #region Handel an Function
    public async Task<int> Handle(AddCategorieCommand request, CancellationToken cancellationToken)
    {
        var result = await _repositoryCategorie.AddCategorie(request.Designation);
        return result;
    }
    #endregion

}
