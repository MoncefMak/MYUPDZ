using MediatR;
using MYUPDZ.Application.Common.Interfaces;
using MYUPDZ.Application.Common.Models;

namespace MYUPDZ.Application.Permissions.Commands.Handlers.Add;

public class AddPermissionsCommandHandler : IRequestHandler<AddPermissionCommand, Result>
{
    #region Fildes
    IIdentityService _identityService;
    #endregion

    #region Constructor
    public AddPermissionsCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }
    #endregion


    #region Handel an Function
    public async Task<Result> Handle(AddPermissionCommand request, CancellationToken cancellationToken)
    {
        var result = await _identityService.AddUserPermissionAsync(request.UserId, request.Designation);
        return (result);
    }
    #endregion

}
