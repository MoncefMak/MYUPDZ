using System.Collections;

namespace MYUPDZ.Domain.Enums;

public class Permission : IEnumerable<string>
{
    private static string[] Actions = new[] { "VIEW", "ADD", "UPDATE", "DELETE", "ARCHIVE" };

    private static string[] Permissions = new[]
    {
        "CATEGORIE", "SOUS_CATEGORIE", "FONCTIONNAIRE", "PERMISSIONS"
    };

    private List<string> additionalPermissions = new List<string> { "Another" };


    public IEnumerator<string> GetEnumerator()
    {
        foreach (string permission in Permissions)
        {
            foreach (string action in Actions)
            {
                yield return action + "_" + permission;
            }
        }

        foreach (string permission in additionalPermissions)
        {
            foreach (string action in Actions)
            {
                yield return action + "_" + permission;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
