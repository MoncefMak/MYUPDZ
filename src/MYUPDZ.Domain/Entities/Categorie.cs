using MYUPDZ.Domain.Common;

namespace MYUPDZ.Domain.Entities;

public class Categorie : BaseAuditableEntity
{

    private Categorie()
    {

    }

    public Categorie(string designation)
    {
        Designation = designation;
    }

    public void Update(string designation)
    {
        Designation = designation;
    }


    public string Designation { get; private set; }

    public IList<SousCategorie> SousCategories { get; } = new List<SousCategorie>();

}
