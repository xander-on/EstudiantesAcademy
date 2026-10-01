using Api.Modules.Carreras.Domain;
using Api.Modules.Carreras.Infrastructure;
using Api.Modules.Shared.Infrastructure.Persistence;
using MediatR;

namespace Api.Modules.Carreras.Application.Features.CreateCarrera;


public class CreateCarreraHandler(AppDbContext context, CarrerasMateriasRepository materias) 
: IRequestHandler<CreateCarreraCommand, Guid>
{

    private readonly AppDbContext _context = context;
    private readonly CarrerasMateriasRepository _materias = materias;

    public async Task<Guid> Handle(
        CreateCarreraCommand command, 
        CancellationToken ct
    )
    {
        var ids = command.MateriasIds?.Distinct().ToList() ?? [];
        await _materias.EnsureExistAsync(ids, ct);

        var carrera = Carrera.Create(
            command.Code,
            command.Name,
            command.Description
        );

        _context.Carreras.Add(carrera);

        foreach(var materiaId in ids)
            _context.CarrerasMaterias.Add(
                CarreraMateria.Create(carrera.Id, materiaId)
            );

        await _context.SaveChangesAsync(ct);
        return carrera.Id;
    }
}