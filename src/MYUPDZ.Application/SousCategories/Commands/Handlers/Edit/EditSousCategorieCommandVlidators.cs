using FluentValidation;
using MYUPDZ.Application.Common.Interfaces.Repository;

namespace MYUPDZ.Application.SousCategories.Commands.Handlers.Edit;

public class EditSousCategorieCommandVlidators : AbstractValidator<EditSousCategorieCommand>
{
    #region Fildes
    public readonly IRepositoryCategorie _categorieRepository;
    public readonly IRepositorySousCategorie _categorieSousRepository;

    #endregion

    #region Construction
    public EditSousCategorieCommandVlidators(IRepositoryCategorie repositoryCategorie, IRepositorySousCategorie repositorySousCategorie)
    {
        _categorieRepository = repositoryCategorie;
        _categorieSousRepository = repositorySousCategorie;
        ApplayValidationRules();
    }
    #endregion

    #region Actions
    public void ApplayValidationRules()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .MustAsync(async (id, cancellationToken) => await _categorieSousRepository.ExistsAsync(id))
            .WithMessage("Sous Categorie not exist");

        RuleFor(x => x.Designation)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .MaximumLength(50)
            .WithMessage("{PropertyName} Max length 50.");

        RuleFor(x => x.CategorieId)
            .GreaterThan(0)
            .MustAsync(async (id, cancellationToken) => await _categorieRepository.ExistsAsync(id))
            .WithMessage("Categorie not exist");
    }
    #endregion

}
