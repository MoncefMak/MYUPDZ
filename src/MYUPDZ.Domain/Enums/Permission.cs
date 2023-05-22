using System.Collections;

namespace MYUPDZ.Domain.Enums;

public class Permission : IEnumerable<string>
{
    private static ReadOnlySpan<string> Actions => new[] { "VIEW", "ADD", "UPDATE", "DELETE", "ARCHIVE" };

    private static ReadOnlySpan<string> Permissions => new[]
    {
        "CATEGORIE", "SOUS_CATEGORIE", "FONCTIONNAIRE", "PERMISSIONS"
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
