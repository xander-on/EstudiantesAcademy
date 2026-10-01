using Api.Modules.Carreras.Domain;
using Api.Modules.Shared.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Api.Modules.Carreras.Infrastructure;

public class CarrerasMateriasRepository(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public async Task SyncAsync(
        Guid carreraId, 
        IReadOnlyList<Guid> materiasIds, 
        CancellationToken ct
    )
    {
        var ids = materiasIds.Distinct().ToList();

        var current = await _context.CarrerasMaterias
            .Where(x => x.CarreraId == carreraId && !x.Deleted)
            .ToListAsync(ct);

        var toRemove = current.Where(x => !ids.Contains(x.MateriaId)).ToList();
        var toAdd = ids.Where(id => current.All(x => x.MateriaId != id)).ToList();

        await EnsureExistAsync(toAdd, ct);

        _context.CarrerasMaterias.RemoveRange(toRemove);

        foreach(var materiaId in toAdd)
            _context.CarrerasMaterias.Add(
                CarreraMateria.Create(carreraId, materiaId)
            );
    }

        

    public async Task EnsureExistAsync(
        IReadOnlyList<Guid> materiasIds, 
        CancellationToken ct
    )
    {
        if(materiasIds.Count == 0)
            return;

        var existingIds = await _context.Materias
            .Where(x => materiasIds.Contains(x.Id) && !x.Deleted)
            .Select(x => x.Id)
            .ToListAsync(ct);

        var missing = materiasIds.Except(existingIds).ToList();

        if(missing.Count > 0)
            throw new Exception($"Materias with ids: {string.Join(",", missing)} not found");
    }
}