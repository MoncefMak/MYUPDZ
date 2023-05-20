using FluentValidation;

namespace MYUPDZ.Application.Categories.Commands.Handlers.Edit;

public class EditCategorieCommandVlidators : AbstractValidator<EditCategorieCommand>
{
    #region Fildes

    #endregion

    #region Construction
    public EditCategorieCommandVlidators()
    {
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
    }
    #endregion

}
