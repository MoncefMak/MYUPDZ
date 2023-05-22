using MediatR;
using MYUPDZ.Application.Common.Bases;
using MYUPDZ.Application.Common.Interfaces;

namespace MYUPDZ.Application.Permissions.Commands.Handlers.Delete;

public class AddPermissionsCommandHandler : ResponseHandler, IRequestHandler<DeletePermissionCommand, Response<string>>
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
    public async Task<Response<string>> Handle(DeletePermissionCommand request, CancellationToken cancellationToken)
    {
        var result = await _identityService.DeleteUserPermissionAsync(request.Designation, request.UserId);
        if (result.Succeeded) return Created("Permission added successfully.");
        return ErrorIdentityEntity<string>(result);

    }
    #endregion

}
