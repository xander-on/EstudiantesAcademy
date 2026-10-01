using Api.Modules.Materias.Domain;
using Api.Modules.Shared.Infrastructure.Persistence;
using MediatR;

namespace Api.Modules.Materias.Application.Features.AddMateria;

public class AddMateriaHandler(AppDbContext context) 
: IRequestHandler<AddMateriaCommand, Guid>
{
    private readonly AppDbContext _context = context;

    public async Task<Guid> Handle(
        AddMateriaCommand command, 
        CancellationToken ct
    )
    {
        var materia = Materia.Create(command.Name, command.Description);
        _context.Materias.Add(materia);
        await _context.SaveChangesAsync(ct);
        return materia.Id;
    }
}