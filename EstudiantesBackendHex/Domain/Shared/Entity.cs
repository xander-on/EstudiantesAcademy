namespace Domain.Shared;


public abstract class Entity
{
    public Guid Id { get; private set; }

    public bool Deleted { get; private set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
        Deleted = false;
    }

    public void Delete() => Deleted = true;
}