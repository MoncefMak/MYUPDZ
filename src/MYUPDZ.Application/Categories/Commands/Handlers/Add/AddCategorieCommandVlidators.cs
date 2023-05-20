using FluentValidation;

namespace MYUPDZ.Application.Categories.Commands.Handlers.Add;

public class AddCategorieCommandVlidators : AbstractValidator<AddCategorieCommand>
{
    #region Fildes

    #endregion

    #region Construction
    public AddCategorieCommandVlidators()
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
