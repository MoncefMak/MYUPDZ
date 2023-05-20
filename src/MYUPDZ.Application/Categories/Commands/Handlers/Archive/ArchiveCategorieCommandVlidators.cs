using FluentValidation;
using MYUPDZ.Application.Common.Interfaces.Repository;

namespace MYUPDZ.Application.Categories.Commands.Handlers.Archive;

public class ArchiveCategorieCommandVlidators : AbstractValidator<ArchiveCategorieCommand>
{
    #region Fildes
    public readonly IRepositoryCategorie _categorieRepository;
    #endregion

    #region Construction
    public ArchiveCategorieCommandVlidators(IRepositoryCategorie repositoryCategorie)
    {
        _categorieRepository = repositoryCategorie;
        ApplayValidationRules();
    }
    #endregion

    #region Actions
    public void ApplayValidationRules()
    {
        RuleFor(x => x.Id)
          .GreaterThan(0)
          .MustAsync(async (id, cancellationToken) => await _categorieRepository.ExistsAsync(id))
          .WithMessage("Categorie not exist");
    }
    #endregion

}
