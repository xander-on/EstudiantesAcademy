using Api.Modules.Carreras.Application.Dtos;
using Api.Modules.Shared.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Modules.Carreras.Application.Features.GetCarreras;


public class GetCarrerasHandler(AppDbContext context)
: IRequestHandler<GetCarrerasQuery, CarreraResponse[]>
{
    private readonly AppDbContext _context = context;

    public async Task<CarreraResponse[]> Handle(
        GetCarrerasQuery query, 
        CancellationToken ct
    )
    {

        var entities = await _context.Carreras
            .Where(c => !c.Deleted && (query.Id == null || c.Id == query.Id))
            .Include(c => c.Materias)
            .AsNoTracking()
            .ToArrayAsync(ct);

        return entities
            .Select(c => new CarreraResponse(
                c.Id,
                c.Code,
                c.Name,
                c.Description,
                c.Materias.Select(cm => cm.MateriaId).ToList()
            ))
            .ToArray();
    }
}