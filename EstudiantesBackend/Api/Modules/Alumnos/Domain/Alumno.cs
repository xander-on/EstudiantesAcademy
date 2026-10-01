using Api.Modules.Shared.Domain;

namespace Api.Modules.Alumnos.Domain;


public class Alumno: Entity
{
    public string Dni { get; private set; } = null!;
    public string Name { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string Email { get; private set; } = null!;

    private Alumno() { }

    private Alumno(
        string dni, 
        string name, 
        string lastName, 
        string email
    )
    {
        Dni      = dni;
        Name     = name;
        LastName = lastName;
        Email    = email;
    }

    public static Alumno Create(
        string dni, 
        string name, 
        string lastName, 
        string email
    )
        => new(dni, name, lastName, email);


    public void Update(
        string? dni,
        string? name,
        string? lastName,
        string? email
    ) 
    { 
        if(dni is not null)
            Dni = dni;

        if(name is not null)
            Name = name;

        if(lastName is not null)
            LastName = lastName;
        
        if(email is not null)
            Email = email;
    }

}

