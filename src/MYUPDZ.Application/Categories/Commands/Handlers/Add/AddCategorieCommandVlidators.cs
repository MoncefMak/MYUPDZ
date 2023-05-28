using FluentValidation;
using MYUPDZ.Application.Common.Interfaces.Repository;

namespace MYUPDZ.Application.Categories.Commands.Handlers.Add;

public class AddCategorieCommandVlidators : AbstractValidator<AddCategorieCommand>
{
    #region Fildes
    public readonly IRepositoryCategorie _categorieRepository;

    #endregion

    #region Construction
    public AddCategorieCommandVlidators(IRepositoryCategorie categorieRepository)
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
            .WithMessage("{PropertyName} Max length 50.")
            .MustAsync(async (designation, cancellationToken) => await _categorieRepository.DesignationExistAsync(designation))
            .WithMessage("Categorie width designation not exist");
    }
    #endregion

}
