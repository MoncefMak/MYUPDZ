using MediatR;
using MYUPDZ.Application.Common.Bases;
using MYUPDZ.Application.Common.Behaviours;

namespace MYUPDZ.Application.Fonctionnaires.Commands.Handlers.Edit;

[Authorize(Policy = "UPDATE_FONCTIONNAIRE")]
public class EditFonctionnaireCommand : IRequest<Response<string>>
{
    public int id { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Email { get; set; }
    public string Matricule { get; set; }
    public string Password { get; set; }
    public string RepeatPassword { get; set; }
    public DateTime DateEmbauche { get; set; }
    public decimal Salaire { get; set; }
}
