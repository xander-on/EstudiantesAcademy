using Application.Materias.Contracts;
using MediatR;

namespace Application.Materias.Features;


public record class DeleteMateriaCommand(
    Guid Id
):IRequest<Guid>;


public class DeleteMateriaHandler(IMateriaRepository repository)
:IRequestHandler<DeleteMateriaCommand, Guid>
{
    private readonly IMateriaRepository _repository = repository;

    public async Task<Guid> Handle(
        DeleteMateriaCommand command, 
        CancellationToken ct
    )
    {
        var materia = await _repository.GetByIdAsync(command.Id, ct) 
            ?? throw new Exception($"Materia with Id {command.Id} not found.");

        await _repository.DeleteAsync(materia, ct);
        return materia.Id;
    }
}