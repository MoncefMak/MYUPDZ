using MediatR;
using MYUPDZ.Application.Common.Interfaces.Repository;

namespace MYUPDZ.Application.Categories.Commands.Handlers.Archive;

public class ArchiveCategorieCommandHandler : IRequestHandler<ArchiveCategorieCommand, Unit>
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
    public async Task<Unit> Handle(ArchiveCategorieCommand request, CancellationToken cancellationToken)
    {
        await _repositoryCategorie.ArchiveCategorieAsync(request.Id);
        return Unit.Value;
    }
    #endregion

}
