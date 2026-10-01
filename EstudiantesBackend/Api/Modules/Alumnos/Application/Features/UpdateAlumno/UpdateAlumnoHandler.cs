using Api.Modules.Shared.Infrastructure.Persistence;
using MediatR;

namespace Api.Modules.Alumnos.Application.Features.UpdateAlumno;

public class UpdateAlumnoHandler(AppDbContext context)
: IRequestHandler<UpdateAlumnoCommand, Guid>
{
    private readonly AppDbContext _context = context;

    public async Task<Guid> Handle(
        UpdateAlumnoCommand command, 
        CancellationToken ct
    )
    {
        var alumno = await _context.Alumnos.FindAsync(command.Id, ct)
            ?? throw new Exception("Alumno not found");

        alumno.Update(command.Dni, command.Name, command.LastName, command.Email);
        await _context.SaveChangesAsync(ct);
        return alumno.Id;
    }
}