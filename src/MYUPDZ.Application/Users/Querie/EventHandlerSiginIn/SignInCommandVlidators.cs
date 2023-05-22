using FluentValidation;

namespace MYUPDZ.Application.Users.Querie.EventHandlerSiginIn;

public class SignInCommandVlidators : AbstractValidator<SignInCommand>
{

    #region Construction
    public SignInCommandVlidators()
    {
        ApplayValidationRules();
    }
    #endregion

    #region Actions
    public void ApplayValidationRules()
    {
        RuleFor(x => x.UserName)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .MaximumLength(50)
            .WithMessage("{PropertyName} Max length 50.");

        RuleFor(x => x.Password)
          .Length(8, 100)
           .WithMessage("{PropertyName} Min length 8."); ;
    }
    #endregion

}
