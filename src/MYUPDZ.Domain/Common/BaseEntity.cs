namespace MYUPDZ.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }

    public bool Archived { get; private set; } = false;

    public void Archive()
    {
        Archived = true;
    }
}