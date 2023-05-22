using MediatR;
using Microsoft.AspNetCore.Mvc;
using MYUPDZ.Application.Common.Bases;
using System.Net;

namespace MYUPDZ.Api.Base;

[ApiController]
public class ApiControllerBase : ControllerBase
{
    private ISender _mediatorInstance;
    //Cette propriété utilise une expression ternaire pour retourner une instance de l'interface IMediator en utilisant le service de requête
    //HttpContext.RequestServices
    protected ISender Mediator => _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();

    #region Actions
    public ObjectResult NewResult<T>(Response<T> response)
    {
        switch (response.StatusCode)
        {
            case HttpStatusCode.OK:
                return new OkObjectResult(response);
            case HttpStatusCode.Created:
                return new CreatedResult(string.Empty, response);
            case HttpStatusCode.Unauthorized:
                return new UnauthorizedObjectResult(response);
            case HttpStatusCode.BadRequest:
                return new BadRequestObjectResult(response);
            case HttpStatusCode.NotFound:
                return new NotFoundObjectResult(response);
            case HttpStatusCode.Accepted:
                return new AcceptedResult(string.Empty, response);
            case HttpStatusCode.UnprocessableEntity:
                return new UnprocessableEntityObjectResult(response);
            default:
                return new BadRequestObjectResult(response);
        }
    }
    #endregion
}
