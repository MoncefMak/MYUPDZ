using FluentValidation;
using MYUPDZ.Application.Common.Interfaces.Repository;

namespace MYUPDZ.Application.Fonctionnaires.Commands.Handlers.Edit;

public class EditFonctionnaireCommandVlidators : AbstractValidator<EditFonctionnaireCommand>
{
    #region Fildes
    IRepositoryFonctionnaire _repositoryFonctionnaire;
    #endregion

    #region Construction
    public EditFonctionnaireCommandVlidators(IRepositoryFonctionnaire repositoryFonctionnaire)
    {
        _repositoryFonctionnaire = repositoryFonctionnaire;
        ApplayValidationRules();
    }
    #endregion

    #region Actions
    public void ApplayValidationRules()
    {
        RuleFor(x => x.Id)
           .GreaterThan(0)
           .MustAsync(async (id, cancellationToken) => await _repositoryFonctionnaire.ExistsAsync(id))
           .WithMessage("Fonctionnaire not exist");

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
