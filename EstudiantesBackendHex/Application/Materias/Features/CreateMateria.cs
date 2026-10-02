using Application.Materias.Contracts;
using Domain.Materias;
using MediatR;

namespace Application.Materias.Features;



public record CreateMateriaCommand(
    string Name,
    string Description
):IRequest<Guid>;



public class CreateMateriaHandler(IMateriaRepository repository)
: IRequestHandler<CreateMateriaCommand, Guid>
{

    private readonly IMateriaRepository _repository = repository;

    public async Task<Guid> Handle(
        CreateMateriaCommand command, 
        CancellationToken ct
    )
    {
        var materia = Materia.Create(command.Name, command.Description);
        var created = await _repository.AddAsync(materia, ct);
        return created.Id;
    }
}