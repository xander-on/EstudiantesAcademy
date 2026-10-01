using Api.Modules.Materias.Application.Features.DeleteMateria;
using Api.Modules.Materias.Domain;
using Api.Modules.Shared.Infrastructure.Persistence;
using MediatR;

namespace Api.Modules.Materias.Application.Features.AddMateria;

public class DeleteMateriaHandler(AppDbContext context) 
: IRequestHandler<DeleteMateriaCommand, Guid>
{
    private readonly AppDbContext _context = context;

    public async Task<Guid> Handle(
        DeleteMateriaCommand command, 
        CancellationToken ct
    )
    {
        var materia = await _context.Materias.FindAsync(command.Id, ct);

        if (materia is null)
            throw new Exception("Materia not found");
        
        materia.Delete();
        await _context.SaveChangesAsync(ct);
        return materia.Id;
    }
}