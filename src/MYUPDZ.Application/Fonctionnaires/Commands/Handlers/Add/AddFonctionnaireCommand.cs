using MediatR;
using MYUPDZ.Application.Common.Behaviours;

namespace MYUPDZ.Application.Fonctionnaires.Commands.Handlers.Add;

[Authorize(Policy = "ADD_FONCTIONNAIRE")]
public class AddFonctionnaireCommand : IRequest<int>
{
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string RepeatPassword { get; set; }
    public string Matricule { get; set; }
    public DateTime DateEmbauche { get; set; }
    public decimal Salaire { get; set; }
}
