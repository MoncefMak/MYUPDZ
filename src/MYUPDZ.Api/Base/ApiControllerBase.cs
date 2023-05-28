using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MYUPDZ.Api.Base;

[ApiController]
public class ApiControllerBase : ControllerBase
{
    private ISender _mediatorInstance;
    //Cette propriété utilise une expression ternaire pour retourner une instance de l'interface IMediator en utilisant le service de requête
    //HttpContext.RequestServices
    protected ISender Mediator => _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();


}
