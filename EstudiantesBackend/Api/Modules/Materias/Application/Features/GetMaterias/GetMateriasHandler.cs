using Api.Modules.Shared.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Modules.Materias.Application.Features.GetMaterias;

public class GetMateriasHandler( 
    AppDbContext context
): IRequestHandler<GetMateriasQuery, MateriasResponse[]>
{
    private readonly AppDbContext _context = context;

    public async Task<MateriasResponse[]> Handle(
        GetMateriasQuery request, 
        CancellationToken ct
    )
    {
        var materias = await _context.Materias
            .Where(m => !m.Deleted)
            .Select(m => new MateriasResponse(m.Id, m.Name, m.Description))
            .ToArrayAsync();

        return materias;
    }
}