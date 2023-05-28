using FluentValidation;

namespace MYUPDZ.Application.Fonctionnaires.Commands.Handlers.Add;

public class AddFonctionnaireCommandValidator : AbstractValidator<AddFonctionnaireCommand>
{
    public AddFonctionnaireCommandValidator()
    {
        RuleFor(x => x.Nom)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("{PropertyName} Max length 50.");

        RuleFor(x => x.Prenom)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(50).WithMessage("{PropertyName} Max length 50.");

        RuleFor(x => x.DateEmbauche)
            .NotEmpty().WithMessage("The DateEmbauche field must be a valid date.");

        RuleFor(x => x.Email)
            .EmailAddress();

        RuleFor(x => x.Password)
            .Length(8, 100);

        RuleFor(x => x.RepeatPassword)
            .NotEmpty().When(x => !string.IsNullOrEmpty(x.Email) && !string.IsNullOrEmpty(x.Password))
            .Equal(x => x.Password);
    }
}
