
namespace Application.Materias.Features;

using Application.Materias.Contracts;
using Application.Materias.Dtos;
using MediatR;


public record GetMateriasQuery(
    Guid? Id
) : IRequest <MateriaResponse[]>;


public class GetMateriasHandler(IMateriaRepository repository)
:IRequestHandler<GetMateriasQuery, MateriaResponse[]>
{
    private readonly IMateriaRepository _repository = repository;

    public async Task<MateriaResponse[]> Handle(
        GetMateriasQuery query, 
        CancellationToken ct
    )
    {
        var materias = await _repository.GetAllAsync(ct);

        if(query.Id != null)
            materias = materias.Where(m => m.Id == query.Id).ToArray();

        return materias
            .Select(m => m.ToResponse())
            .ToArray();
    }
}