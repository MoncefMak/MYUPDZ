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

    public Categorie Update(string designation)
    {
        Designation = designation;
        return this;
    }


    public string Designation { get; private set; }

    public IList<SousCategorie> SousCategories { get; } = new List<SousCategorie>();

}
