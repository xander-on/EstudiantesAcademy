using Api.Modules.Shared.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Modules.Alumnos.Application.Features.GetAlumnos;

public class GetAlumnosHandler(AppDbContext context) 
: IRequestHandler<GetAlumnosQuery, AlumnoResponse[]>
{

    private readonly AppDbContext _context = context;

    public async Task<AlumnoResponse[]> Handle(
        GetAlumnosQuery request, 
        CancellationToken ct
    )
    {
        var alumnos = await _context.Alumnos
            .Where(a => !a.Deleted)
            .Select(a => new AlumnoResponse(a.Id, a.Dni, a.Name, a.LastName, a.Email))
            .ToArrayAsync();

        return alumnos;
    }
}