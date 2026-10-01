using Api.Modules.Materias.Application.Features.AddMateria;
using Api.Modules.Materias.Application.Features.DeleteMateria;
using Api.Modules.Materias.Application.Features.GetMaterias;
using Api.Modules.Materias.Application.Features.UpdateMateria;

namespace Api.Modules.Materias;

public static class MateriasModule
{
    // public static void AddMateriasServices(this IServiceCollection services){}

    public static void MapMateriasEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints
        .MapGroup("/api/materias")
        .WithTags("Materias");

        group.MapGetMateriasEndpoint();
        group.MapAddMateriaEndpoint();
        group.MapDeleteMateriaEndpoint();
        group.MapUpdateMateriaEndpoint();
    }

}