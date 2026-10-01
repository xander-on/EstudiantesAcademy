using MediatR;

namespace Api.Modules.Materias.Application.Features.DeleteMateria;

public record DeleteMateriaCommand(
    Guid Id
):IRequest<Guid>;
