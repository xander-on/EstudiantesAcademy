using Api.Modules.Shared.Infrastructure.Persistence;
using MediatR;

namespace Api.Modules.Materias.Application.Features.UpdateMateria;


public class UpdateMateriaHandler(AppDbContext context)
: IRequestHandler<UpdateMateriaCommand, Guid>
{
    private readonly AppDbContext _context = context;

    public async Task<Guid> Handle(
        UpdateMateriaCommand command, 
        CancellationToken ct
    )
    {
        var materia = await _context.Materias.FindAsync(command.Id, ct) 
            ?? throw new Exception("Materia not found");
            
        materia.Update(command.Name, command.Description);
        await _context.SaveChangesAsync(ct);
        return materia.Id;
    }
}