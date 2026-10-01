using Api.Modules.Shared.Infrastructure.Persistence;
using MediatR;

namespace Api.Modules.Alumnos.Application.Features.DeleteAlumno;


public class DeleteAlumnoHandler(
    AppDbContext context
) : IRequestHandler<DeleteAlumnoCommand, Guid>
{
    private readonly AppDbContext _context = context;

    public async Task<Guid> Handle(
        DeleteAlumnoCommand command, 
        CancellationToken ct
    )
    {
        var alumno = await _context.Alumnos.FindAsync(command.Id, ct) 
            ?? throw new Exception("Alumno not found");
            
        alumno.Delete();
        await _context.SaveChangesAsync(ct);
        return alumno.Id;
    }
}