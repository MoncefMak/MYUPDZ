using System.Collections;

namespace MYUPDZ.Domain.Enums;

public class Permission : IEnumerable<string>
{
    private static ReadOnlySpan<string> Actions => new[] { "ADD", "UPDATE", "DELETE", "VIEW" };

    private static ReadOnlySpan<string> Permissions => new[]
    {
        "CATEGORIE", "SOUS_CATEGORIE", "PRODUIT", "PRODUIT_TAILLE", "PRODUIT_COULEUR", "PRODUIT_LOT",
        "PRODUIT_MAGASIN", "PRODUIT_STOCK", "PRODUIT_MOUVEMENT", "TRS_TRESORERIE", "TRS_CLIENT_FOURNISSEUR"
    };

    public IEnumerator<string> GetEnumerator()
    {
        string[] result = new string[Actions.Length * Permissions.Length];
        int i = 0;
        foreach (string permission in Permissions)
        {
            foreach (string action in Actions)
            {
                result[i++] = action + "_" + permission;
            }
        }

        return ((IEnumerable<string>)result).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
