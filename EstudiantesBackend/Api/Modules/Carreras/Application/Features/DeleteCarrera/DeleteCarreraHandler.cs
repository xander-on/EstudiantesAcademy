using Api.Modules.Shared.Infrastructure.Persistence;
using MediatR;

namespace Api.Modules.Carreras.Application.Features.DeleteCarrera;


public class DeleteCarreraHandler(AppDbContext context)
: IRequestHandler<DeleteCarreraCommand, Guid>
{

    private readonly AppDbContext _context = context;

    public async Task<Guid> Handle(
        DeleteCarreraCommand command, 
        CancellationToken ct
    )
    {
        var carrera = await _context.Carreras.FindAsync(command.Id) 
            ?? throw new Exception("Carrera not found");

        carrera.Delete();
        _context.SaveChanges();
        return carrera.Id;
    }
}