
using Domain.Materias;

namespace Application.Materias.Dtos;

public record MateriaResponse(
    Guid Id,
    string Name,
    string Description
);


public static class MateriaResponseMapper
{
    public static MateriaResponse ToResponse(this Materia materia)
    {
        return new MateriaResponse(
            Id          : materia.Id,
            Name        : materia.Name,
            Description : materia.Description
        );
    }
}