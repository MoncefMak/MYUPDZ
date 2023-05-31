using FluentValidation;
using Newtonsoft.Json;
using System.Net;

namespace MYUPDZ.Api.Common;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            // Gérer les erreurs de validation et envoyer une réponse appropriée à l'utilisateur
            var messagesErreurs = ex.Errors.Select(erreur => erreur.ErrorMessage).ToList();
            var messageErreur = string.Join(", ", messagesErreurs);

            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";

            var reponseErreur = new
            {
                Message = messageErreur
            };

            var reponseJsonErreur = JsonConvert.SerializeObject(reponseErreur);
            await context.Response.WriteAsync(reponseJsonErreur);
        }
    }
}
