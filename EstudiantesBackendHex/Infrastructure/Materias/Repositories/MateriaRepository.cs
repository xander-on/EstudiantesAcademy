using Application.Materias.Contracts;
using Domain.Materias;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Materias.Repositories;

public class MateriaRepository(AppDbContext context) 
: IMateriaRepository
{
    private readonly AppDbContext _context = context;


    public async Task<bool> Exists(Guid id, CancellationToken ct)
        => await _context.Materias.AnyAsync(m => m.Id == id, ct);

    public async Task<Materia[]> GetAllAsync(CancellationToken ct)
        => await _context.Materias
            .Where(m => !m.Deleted)
            .ToArrayAsync(ct);
    

    public async Task<Materia?> GetByIdAsync(Guid id, CancellationToken ct)
        => await _context.Materias.FirstOrDefaultAsync(m => m.Id == id, ct);
    

    public async Task<Materia> AddAsync(Materia materia, CancellationToken ct)
    {
        await _context.Materias.AddAsync(materia, ct);
        await _context.SaveChangesAsync(ct);
        return materia;
    }

    // public async Task UpdateAsync(Materia materia, CancellationToken ct)
    // {
    //     _context.Materias.Update(materia);
    //     await _context.SaveChangesAsync(ct);
    // }

    public async Task DeleteAsync(Materia materia, CancellationToken ct)
    {
        materia.Delete();
        await _context.SaveChangesAsync(ct);
    }
}