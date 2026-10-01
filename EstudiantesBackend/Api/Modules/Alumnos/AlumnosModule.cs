using Api.Modules.Alumnos.Application.Features.CreateAlumno;
using Api.Modules.Alumnos.Application.Features.DeleteAlumno;
using Api.Modules.Alumnos.Application.Features.GetAlumnos;
using Api.Modules.Alumnos.Application.Features.UpdateAlumno;

namespace Api.Modules.Alumnos;


public static class AlumnosModule
{
    public static void MapAlumnosEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints
            .MapGroup("/api/alumnos")
            .WithTags("Alumnos");

        group.MapGetAlumnosEndpoint();
        group.MapCreateAlumnoEndpoint();
        group.MapDeleteAlumnoEndpoint();
        group.MapUpdateAlumnoEndpoint();
    }
}