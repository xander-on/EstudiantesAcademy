using Api.Modules.Carreras.Infrastructure;
using Api.Modules.Shared.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Modules.Carreras.Application.Features.UpdateCarrera;


public class UpdateCarreraHandler(AppDbContext context, CarrerasMateriasRepository materias) 
: IRequestHandler<UpdateCarreraCommand, Guid>
{

    private readonly AppDbContext _context = context;
    private readonly CarrerasMateriasRepository _materias = materias;

    public async Task<Guid> Handle(
        UpdateCarreraCommand command, 
        CancellationToken ct
    )
    {
        var carrera = await _context.Carreras
            .FirstOrDefaultAsync(x => x.Id == command.Id && !x.Deleted, ct)
            ?? throw new Exception("Carrera not found");

        carrera.Update(command.Code, command.Name, command.Description);

        if(command.MateriasIds is not null)
            await _materias.SyncAsync(carrera.Id, command.MateriasIds, ct);

        await _context.SaveChangesAsync(ct);
        return carrera.Id;
    }
}