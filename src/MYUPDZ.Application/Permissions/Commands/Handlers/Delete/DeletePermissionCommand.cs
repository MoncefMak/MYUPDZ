using MediatR;
using MYUPDZ.Application.Common.Behaviours;
using MYUPDZ.Application.Common.Models;

namespace MYUPDZ.Application.Permissions.Commands.Handlers.Delete;

[Authorize(Policy = "DELETE_PERMISSIONS")]
public class DeletePermissionCommand : IRequest<Result>
{
    public string Designation { get; set; }
    public string UserId { get; set; }

}
