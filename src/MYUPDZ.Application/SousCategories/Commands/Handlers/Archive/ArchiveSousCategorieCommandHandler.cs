using MediatR;
using MYUPDZ.Application.Common.Interfaces.Repository;

namespace MYUPDZ.Application.SousCategories.Commands.Handlers.Archive;

public class ArchiveSousCategorieCommandHandler : IRequestHandler<ArchiveSousCategorieCommand, Unit>
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
    public async Task<Unit> Handle(ArchiveSousCategorieCommand request, CancellationToken cancellationToken)
    {
        await _repositoryCategorie.ArchiveCategorieAsync(request.Id);
        return Unit.Value;
    }
    #endregion

}
