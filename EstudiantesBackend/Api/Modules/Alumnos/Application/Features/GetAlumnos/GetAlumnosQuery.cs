
using MediatR;
namespace Api.Modules.Alumnos.Application.Features.GetAlumnos;


public record GetAlumnosQuery():IRequest<AlumnoResponse[]>;


public record AlumnoResponse(
    Guid Id,
    string Dni,
    string Name,
    string LastName,
    string Email
);