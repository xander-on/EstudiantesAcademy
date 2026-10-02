
namespace Application.Materias.Contracts;



using Domain.Materias;

public interface IMateriaRepository
{
    Task<bool> Exists(Guid id, CancellationToken ct);
    Task<Materia[]> GetAllAsync(CancellationToken ct);
    Task<Materia?> GetByIdAsync(Guid id, CancellationToken ct);
    Task<Materia> AddAsync(Materia materia, CancellationToken ct);
    // Task UpdateAsync(Materia materia, CancellationToken ct);
    Task DeleteAsync(Materia materia, CancellationToken ct);
}