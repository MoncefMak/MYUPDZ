namespace MYUPDZ.Domain.AppMetaData;

public static class Router
{
    public const string root = "Api";
    public const string list = "List";
    public const string getById = "{id}";
    public const string create = "Add";
    public const string edit = "Edit";
    public const string delete = "Delete";
    public const string archive = "Archive";
    public const string signin = "SignIn";

    private const string categoriePrefix = "Categorie";
    private const string sousCategoriePrefix = "SousCategorie";
    private const string fonctionnairePrefix = "Fonctionnaire";
    private const string userPrefix = "Users";
    private const string permissionPrefix = "Permission";

    public static class CategorieRoute
    {
        private const string prefix = $"{root}/{categoriePrefix}";
        public const string List = $"{prefix}/{list}";
        public const string GetById = $"{prefix}/{getById}";
        public const string Add = $"{prefix}/{create}";
        public const string Edit = $"{prefix}/{edit}";
        public const string Archive = $"{prefix}/{archive}";
    }

    public static class SousCategorieRoute
    {
        private const string prefix = $"{root}/{sousCategoriePrefix}";

        public const string List = $"{prefix}/{list}";
        public const string GetById = $"{prefix}/{getById}";
        public const string Add = $"{prefix}/{create}";
        public const string Edit = $"{prefix}/{edit}";
        public const string Archive = $"{prefix}/{archive}";
    }

    public static class FonctionnaireRoute
    {
        private const string prefix = $"{root}/{fonctionnairePrefix}";
        public const string List = $"{prefix}/{list}";
        public const string GetById = $"{prefix}/{getById}";
        public const string Add = $"{prefix}/{create}";
        public const string Edit = $"{prefix}/{edit}";
        public const string Archive = $"{prefix}/{archive}";
    }
    public static class UserRoute
    {
        private const string prefix = $"{root}/{userPrefix}";
        public const string SignIn = $"{prefix}/{signin}";
    }

    public static class PermissionRoute
    {
        private const string prefix = $"{root}/{permissionPrefix}";
        public const string Add = $"{prefix}/{create}";
        public const string Delete = $"{prefix}/{delete}";
    }
}
