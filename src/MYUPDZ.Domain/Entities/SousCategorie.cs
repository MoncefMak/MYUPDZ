using MYUPDZ.Domain.Common;

namespace MYUPDZ.Domain.Entities;

public class SousCategorie : BaseAuditableEntity
{

    private SousCategorie()
    {
    }

    public SousCategorie(string designation, int categorieId)
    {
        Designation = designation;
        CategorieId = categorieId;
    }

    public void Update(string designation, int categorieId)
    {
        Designation = designation;
        CategorieId = categorieId;
    }

    public string Designation { get; private set; }
    public int CategorieId { get; private set; }
    public Categorie Categorie { get; set; }


}