using MediatR;
using MYUPDZ.Application.Common.Interfaces;
using MYUPDZ.Application.Common.Models;

namespace MYUPDZ.Application.Permissions.Commands.Handlers.Delete;

public class AddPermissionsCommandHandler : IRequestHandler<DeletePermissionCommand, Result>
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
    public async Task<Result> Handle(DeletePermissionCommand request, CancellationToken cancellationToken)
    {
        var result = await _identityService.DeleteUserPermissionAsync(request.Designation, request.UserId);
        return result;
    }
    #endregion

}
