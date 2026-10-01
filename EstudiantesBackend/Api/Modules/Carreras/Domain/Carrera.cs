using Api.Modules.Shared.Domain;

namespace Api.Modules.Carreras.Domain;


public class Carrera : Entity
{
    public string Code { get; private set; } = null!;
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;

    public ICollection<CarreraMateria> Materias { get; private set; } = new List<CarreraMateria>();

    protected Carrera() { }

    private Carrera(
        string code, 
        string name, 
        string description
    )
    {
        Code = code;
        Name = name;
        Description = description;
    }


    public static Carrera Create(
        string code, 
        string name, 
        string description
    )
        => new(code, name, description);


    public void Update(
        string? code, 
        string? name, 
        string? description
    )
    {
        if(code is not null)
            Code = code;

        if(name is not null)
            Name = name;

        if(description is not null)
            Description = description;
    }

}