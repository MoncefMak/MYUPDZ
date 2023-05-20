using FluentValidation;
using MYUPDZ.Application.Common.Interfaces.Repository;

namespace MYUPDZ.Application.SousCategories.Commands.Handlers.Add;

public class AddSousCategorieCommandVlidators : AbstractValidator<AddSousCategorieCommand>
{
    #region Fildes
    public readonly IRepositoryCategorie _categorieRepository;
    #endregion

    #region Construction
    public AddSousCategorieCommandVlidators(IRepositoryCategorie categorieRepository)
    {
        _categorieRepository = categorieRepository;
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
            .WithMessage("{PropertyName} Max length 50.");

        RuleFor(x => x.CategorieId)
         .GreaterThan(0)
         .MustAsync(async (id, cancellationToken) => await _categorieRepository.ExistsAsync(id))
         .WithMessage("Categorie not exist");
    }
    #endregion

}
