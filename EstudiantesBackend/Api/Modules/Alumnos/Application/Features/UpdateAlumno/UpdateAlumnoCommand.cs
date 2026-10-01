using MediatR;

namespace Api.Modules.Alumnos.Application.Features.UpdateAlumno;



public record UpdateAlumnoCommand(
    Guid Id,
    string? Dni,
    string? Name,
    string? LastName,
    string? Email
):IRequest<Guid>;


public record UpdateAlumnoRequest(
    string? Dni,
    string? Name,
    string? LastName,
    string? Email
);