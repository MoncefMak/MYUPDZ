using FluentValidation;
using MYUPDZ.Application.Common.Interfaces.Repository;

namespace MYUPDZ.Application.SousCategories.Commands.Handlers.Add;

public class AddSousCategorieCommandVlidators : AbstractValidator<AddSousCategorieCommand>
{
    #region Fildes
    public readonly IRepositoryCategorie _categorieRepository;
    public readonly IRepositorySousCategorie _repositorySousCategorie;
    #endregion

    #region Construction
    public AddSousCategorieCommandVlidators(IRepositoryCategorie categorieRepository, IRepositorySousCategorie repositorySousCategorie)
    {
        _categorieRepository = categorieRepository;
        _repositorySousCategorie = repositorySousCategorie;
        ApplayValidationRules();
    }
    #endregion

    #region Actions
    public void ApplayValidationRules()
    {
        RuleFor(x => x.Designation)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .MaximumLength(50)
            .WithMessage("{PropertyName} Max length 50.")
            .MustAsync(async (designation, cancellationToken) => await _repositorySousCategorie.DesignationExistAsync(designation))
            .WithMessage("Categorie not exist");

        RuleFor(x => x.CategorieId)
         .GreaterThan(0)
         .MustAsync(async (id, cancellationToken) => await _categorieRepository.ExistsAsync(id))
         .WithMessage("Categorie not exist");
    }
    #endregion

}
