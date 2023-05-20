using MediatR;
using MYUPDZ.Application.Common.Bases;
using MYUPDZ.Application.Common.Interfaces.Repository;

namespace MYUPDZ.Application.SousCategories.Commands.Handlers.Add;

public class AddSousCategorieCommandHandler : ResponseHandler, IRequestHandler<AddSousCategorieCommand, Response<string>>
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
    public async Task<Response<string>> Handle(AddSousCategorieCommand request, CancellationToken cancellationToken)
    {
        var result = await _repositorySousCategorie.AddSousCategorieAsync(request.Designation, request.CategorieId);
        if (!result) return UnprocessableEntity<string>("Categorie With this Designation exist");
        else if (result) return Created("Add Sussessfully");
        return BadRequest<string>();
    }
    #endregion

}
