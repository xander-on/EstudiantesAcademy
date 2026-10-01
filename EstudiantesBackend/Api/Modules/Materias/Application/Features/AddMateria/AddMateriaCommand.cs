using MediatR;

namespace Api.Modules.Materias.Application.Features.AddMateria;


public record AddMateriaRequest(
    string Name,
    string Description
);

public record AddMateriaCommand(
    string Name,
    string Description
):IRequest<Guid>;
