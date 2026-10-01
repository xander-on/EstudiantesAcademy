
using Api.Modules.Alumnos.Domain;
using Api.Modules.Shared.Infrastructure.Persistence;
using MediatR;

namespace Api.Modules.Alumnos.Application.Features.CreateAlumno;


public class CreateAlumnoHandler(AppDbContext context) : IRequestHandler<CreateAlumnoCommand, Guid>
{

    private readonly AppDbContext _context = context;

    public async Task<Guid> Handle(
        CreateAlumnoCommand command, 
        CancellationToken ct
    )
    {
        var alumno = Alumno.Create(
            command.Dni,
            command.Name,
            command.LastName,
            command.Email
        );

        _context.Alumnos.Add(alumno);
        await _context.SaveChangesAsync(ct);
        return alumno.Id;
    }
}