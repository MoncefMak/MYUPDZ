using MediatR;
using MYUPDZ.Application.Common.Bases;
using MYUPDZ.Application.Common.Behaviours;

namespace MYUPDZ.Application.Permissions.Commands.Handlers.Add;

[Authorize(Policy = "ADD_PERMISSIONS")]
public class AddPermissionCommand : IRequest<Response<string>>
{
    public string Designation { get; set; }
    public string UserId { get; set; }

}
