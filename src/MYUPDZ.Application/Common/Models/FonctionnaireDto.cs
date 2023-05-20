namespace MYUPDZ.Application.Common.Models;

public class FonctionnaireDto
{
    public int Id { get; set; }
    public string Nom { get; private set; }
    public string Prenom { get; private set; }
    public string Matricule { get; private set; }
    public DateTime DateEmbauche { get; private set; }
    public decimal Salaire { get; private set; }
    public string? User { get; private set; }
}
