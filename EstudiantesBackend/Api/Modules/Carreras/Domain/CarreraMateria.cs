

using Api.Modules.Materias.Domain;
using Api.Modules.Shared.Domain;

namespace Api.Modules.Carreras.Domain;

public class CarreraMateria : Entity
{
    public Guid CarreraId { get; private set; }
    public Carrera Carrera { get; private set; } = null!;
    public Guid MateriaId { get; private set; }
    public Materia Materia { get; private set; } = null!;


    protected CarreraMateria() { }

    private CarreraMateria(
        Guid carreraId, 
        Guid materiaId
    )
    {
        CarreraId = carreraId;
        MateriaId = materiaId;
    }


    public static CarreraMateria Create(
        Guid carreraId, 
        Guid materiaId
    )
        => new(carreraId, materiaId);
}