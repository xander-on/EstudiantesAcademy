
using MediatR;

namespace Api.Modules.Alumnos.Application.Features.DeleteAlumno;

public record DeleteAlumnoCommand (
    Guid Id
):IRequest<Guid>;