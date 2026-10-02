
using Domain.Shared;

namespace Domain.Materias;

public class Materia:Entity
{
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;

    private Materia(){}

    private Materia(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public static Materia Create(string name, string description)
    {
        return new Materia(name, description);
    }
}