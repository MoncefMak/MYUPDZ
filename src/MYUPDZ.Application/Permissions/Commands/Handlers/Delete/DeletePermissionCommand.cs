using MediatR;
using MYUPDZ.Application.Common.Bases;
using MYUPDZ.Application.Common.Behaviours;

namespace MYUPDZ.Application.Permissions.Commands.Handlers.Delete;

[Authorize(Policy = "DELETE_PERMISSIONS")]
public class DeletePermissionCommand : IRequest<Response<string>>
{
    public string Designation { get; set; }
    public string UserId { get; set; }

}
