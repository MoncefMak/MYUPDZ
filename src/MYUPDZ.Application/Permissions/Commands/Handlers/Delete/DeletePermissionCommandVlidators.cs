using FluentValidation;
using MYUPDZ.Application.Common.Interfaces;

namespace MYUPDZ.Application.Permissions.Commands.Handlers.Delete;

public class DeletePermissionCommandVlidators : AbstractValidator<DeletePermissionCommand>
{
    #region Fildes
    IIdentityService _identityService;
    #endregion

    #region Construction
    public DeletePermissionCommandVlidators(IIdentityService identityService)
    {
        _identityService = identityService;
        ApplayValidationRules();
    }
    #endregion

    #region Actions
    public void ApplayValidationRules()
    {
        RuleFor(x => x.Designation)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .MustAsync(async (permission, cancellationToken) => await _identityService.CheckPermissionExists(permission))
            .WithMessage("Permission not exist")
            .MaximumLength(50)
            .WithMessage("{PropertyName} Max length 50.");

        RuleFor(x => x.UserId)
            .NotEmpty()
            .MustAsync(async (id, cancellationToken) => await _identityService.ExistsActiveUserAsync(id))
            .WithMessage("User not exist");
    }
    #endregion

}
