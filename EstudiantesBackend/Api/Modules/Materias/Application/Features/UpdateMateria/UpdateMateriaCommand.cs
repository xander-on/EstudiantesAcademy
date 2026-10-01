using MediatR;

namespace Api.Modules.Materias.Application.Features.UpdateMateria;

public record UpdateMateriaCommand(
    Guid Id,
    string? Name,
    string? Description
):IRequest<Guid>;


public record UpdateMateriaRequest(
    string? Name,
    string? Description
);