using MediatR;
using MYUPDZ.Application.Common.Bases;
using MYUPDZ.Application.Common.Interfaces.Repository;

namespace MYUPDZ.Application.Categories.Commands.Handlers.Add;

public class AddCategorieCommandHandler : ResponseHandler, IRequestHandler<AddCategorieCommand, Response<string>>
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
    public async Task<Response<string>> Handle(AddCategorieCommand request, CancellationToken cancellationToken)
    {
        var result = await _repositoryCategorie.AddCategorieAsync(request.Designation);
        if (!result) return UnprocessableEntity<string>("Categorie With this Designation exist");
        else if (result) return Created("Add Sussessfully");
        return BadRequest<string>();
    }
    #endregion

}
