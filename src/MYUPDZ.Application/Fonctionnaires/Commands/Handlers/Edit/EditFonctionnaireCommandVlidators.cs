using FluentValidation;

namespace MYUPDZ.Application.Fonctionnaires.Commands.Handlers.Edit;

public class EditFonctionnaireCommandVlidators : AbstractValidator<EditFonctionnaireCommand>
{
    #region Fildes

    #endregion

    #region Construction
    public EditFonctionnaireCommandVlidators()
    {
        ApplayValidationRules();
    }
    #endregion

    #region Actions
    public void ApplayValidationRules()
    {
        RuleFor(x => x.Nom)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .MaximumLength(50)
            .WithMessage("{PropertyName} Max length 50.");

        RuleFor(x => x.Prenom)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .MaximumLength(50)
            .WithMessage("{PropertyName} Max length 50.");

        RuleFor(x => x.Matricule)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .MaximumLength(50)
            .WithMessage("{PropertyName} Max length 50.");

        RuleFor(x => x.DateEmbauche)
           .NotEmpty()
            .WithMessage("The DateEmbauche field must be a valid date.");

        RuleFor(x => x.Email)
            .EmailAddress();

        RuleFor(x => x.Password)
            .Length(8, 100);

        RuleFor(x => x.RepeatPassword)
            .NotEmpty()
            .When(x => !string.IsNullOrEmpty(x.Email) && !string.IsNullOrEmpty(x.Password))
            .Equal(x => x.Password);
    }
    #endregion

}
