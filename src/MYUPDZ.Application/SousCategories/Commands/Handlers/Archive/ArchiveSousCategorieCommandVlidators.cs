using FluentValidation;
using MYUPDZ.Application.Common.Interfaces.Repository;

namespace MYUPDZ.Application.SousCategories.Commands.Handlers.Archive;

public class ArchiveSousCategorieCommandVlidators : AbstractValidator<ArchiveSousCategorieCommand>
{
    #region Fildes
    public readonly IRepositorySousCategorie _categorieSousRepository;
    #endregion

    #region Construction
    public ArchiveSousCategorieCommandVlidators(IRepositorySousCategorie categorieSousRepository)
    {
        _categorieSousRepository = categorieSousRepository;
        ApplayValidationRules();
    }
    #endregion

    #region Actions
    public void ApplayValidationRules()
    {
        RuleFor(x => x.Id)
          .GreaterThan(0)
          .MustAsync(async (id, cancellationToken) => await _categorieSousRepository.ExistsAsync(id))
          .WithMessage("Categorie not exist");
    }
    #endregion

}
