using Api.Modules.Materias.Domain;
using MediatR;

namespace Api.Modules.Materias.Application.Features.GetMaterias;


public record GetMateriasQuery(): IRequest<MateriasResponse[]>;


public record MateriasResponse(
    Guid Id,
    string Name,
    string Description
);