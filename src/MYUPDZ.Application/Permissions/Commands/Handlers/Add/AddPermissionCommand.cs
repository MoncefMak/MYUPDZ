using MediatR;
using MYUPDZ.Application.Common.Behaviours;
using MYUPDZ.Application.Common.Models;

namespace MYUPDZ.Application.Permissions.Commands.Handlers.Add;

[Authorize(Policy = "ADD_PERMISSIONS")]
public class AddPermissionCommand : IRequest<Result>
{
    public string Designation { get; set; }
    public string UserId { get; set; }

}
