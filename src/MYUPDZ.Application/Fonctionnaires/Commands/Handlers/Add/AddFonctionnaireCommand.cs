using MediatR;
using MYUPDZ.Application.Common.Bases;

namespace MYUPDZ.Application.Fonctionnaires.Commands.Handlers.Add;

public class AddFonctionnaireCommand : IRequest<Response<string>>
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
