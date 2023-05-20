using MediatR;
using MYUPDZ.Application.Common.Bases;
using MYUPDZ.Application.Common.Interfaces.Repository;

namespace MYUPDZ.Application.SousCategories.Commands.Handlers.Archive;

public class ArchiveSousCategorieCommandHandler : ResponseHandler, IRequestHandler<ArchiveSousCategorieCommand, Response<string>>
{
    #region Fildes
    private readonly IRepositoryCategorie _repositoryCategorie;
    #endregion

    #region Constructor
    public ArchiveSousCategorieCommandHandler(IRepositoryCategorie repositoryCategorie)
    {
        _repositoryCategorie = repositoryCategorie;
    }
    #endregion


    #region Handel an Function
    public async Task<Response<string>> Handle(ArchiveSousCategorieCommand request, CancellationToken cancellationToken)
    {
        var result = await _repositoryCategorie.ArchiveCategorieAsync(request.Id);
        return Success("Archived Successfully");
    }
    #endregion

}
