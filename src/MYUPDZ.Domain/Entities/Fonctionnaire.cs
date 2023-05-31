using MYUPDZ.Domain.Common;

namespace MYUPDZ.Domain.Entities;

public class Fonctionnaire : BaseAuditableEntity
{

    private Fonctionnaire()
    {

    }

    public Fonctionnaire(string nom, string prenom, string matricule, string email, DateTime dateEmbauche, decimal salaire)
    {
        Nom = nom;
        Prenom = prenom;
        Matricule = matricule;
        Email = email;
        DateEmbauche = dateEmbauche;
        Salaire = salaire;
    }

    public void Update(string nom, string prenom, string matricule, string email, DateTime dateEmbauche, decimal salaire)
    {
        Nom = nom;
        Prenom = prenom;
        Matricule = matricule;
        Email = email;
        DateEmbauche = dateEmbauche;
        Salaire = salaire;
    }


    public bool HasUser => !string.IsNullOrEmpty(User);
    public void AssignUser(string userId)
    {
        User = userId;
    }
    public string Nom { get; private set; }
    public string Prenom { get; private set; }
    public string Matricule { get; private set; }
    public string Email { get; private set; }
    public DateTime DateEmbauche { get; private set; }
    public decimal Salaire { get; private set; }
    public string? User { get; private set; }


    public override bool Equals(object? obj)
    {
        return obj is Fonctionnaire fonctionnaire &&
               Id == fonctionnaire.Id &&
               Created == fonctionnaire.Created &&
               CreatedBy == fonctionnaire.CreatedBy &&
               LastModified == fonctionnaire.LastModified &&
               LastModifiedBy == fonctionnaire.LastModifiedBy &&
               Archived == fonctionnaire.Archived &&
               Nom == fonctionnaire.Nom &&
               Prenom == fonctionnaire.Prenom &&
               Matricule == fonctionnaire.Matricule &&
               DateEmbauche == fonctionnaire.DateEmbauche &&
               Salaire == fonctionnaire.Salaire &&
               User == fonctionnaire.User;
    }
}