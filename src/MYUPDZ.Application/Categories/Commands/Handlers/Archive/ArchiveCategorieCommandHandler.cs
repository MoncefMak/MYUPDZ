using MediatR;
using MYUPDZ.Application.Common.Bases;
using MYUPDZ.Application.Common.Interfaces.Repository;

namespace MYUPDZ.Application.Categories.Commands.Handlers.Archive;

public class ArchiveCategorieCommandHandler : ResponseHandler, IRequestHandler<ArchiveCategorieCommand, Response<string>>
{
    #region Fildes
    private readonly IRepositoryCategorie _repositoryCategorie;
    #endregion

    #region Constructor
    public ArchiveCategorieCommandHandler(IRepositoryCategorie repositoryCategorie)
    {
        _repositoryCategorie = repositoryCategorie;
    }
    #endregion


    #region Handel an Function
    public async Task<Response<string>> Handle(ArchiveCategorieCommand request, CancellationToken cancellationToken)
    {
        var result = await _repositoryCategorie.ArchiveCategorieAsync(request.Id);
        return Success("Archived Successfully");
    }
    #endregion

}
