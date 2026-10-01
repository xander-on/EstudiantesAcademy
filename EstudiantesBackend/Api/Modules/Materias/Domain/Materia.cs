using Api.Modules.Shared.Domain;

namespace Api.Modules.Materias.Domain;


public class Materia : Entity
{
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;

    private Materia() { }

    private Materia(
        string name, 
        string description
    )
    {
        Name = name;
        Description = description;
    }


    public static Materia Create(
        string name, 
        string description
    )
        => new(name, description);


    public void Update(
        string? name, 
        string? description
    )
    {
        if(name is not null)
            Name = name;

        if(description is not null)
            Description = description;
    }

}