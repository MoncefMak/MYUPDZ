using FluentValidation;
using MYUPDZ.Application.Common.Interfaces.Repository;

namespace MYUPDZ.Application.Categories.Commands.Handlers.Edit;

public class EditCategorieCommandVlidators : AbstractValidator<EditCategorieCommand>
{
    #region Fildes
    public readonly IRepositoryCategorie _repositoryCategory;
    #endregion

    #region Construction
    public EditCategorieCommandVlidators(IRepositoryCategorie repositoryCategory)
    {
        _repositoryCategory = repositoryCategory;
        ApplayValidationRules();
    }
    #endregion

    #region Actions
    public void ApplayValidationRules()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .MustAsync(async (id, cancellationToken) => await _repositoryCategory.ExistsAsync(id))
            .WithMessage("Categorie not exist");

        RuleFor(x => x.Designation)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .MaximumLength(50)
            .WithMessage("{PropertyName} Max length 50.")
            .MustAsync(async (command, designation, cancellationToken) => !(await _repositoryCategory.DesignationExistIdAsync(command.Id, designation)))
            .WithMessage("Category with the same designation already exists with a different Id.");

    }
    #endregion

}
