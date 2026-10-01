using Api.Modules.Alumnos;
using Api.Modules.Carreras;
using Api.Modules.Materias;
using Api.Modules.Shared;

namespace Api.Modules;

public static class ModuleExtensions
{
    public static void AddModulesServices(this IServiceCollection services)
    {
        SharedModule.AddServices(services);
        CarrerasModule.AddServices(services);
    }


    public static void MapModulesEndpoints(this IEndpointRouteBuilder endpoints)
    {
        MateriasModule.MapMateriasEndpoints(endpoints);
        AlumnosModule.MapAlumnosEndpoints(endpoints);
        CarrerasModule.MapCarrerasEndpoints(endpoints);
        // PersonsModule.MapEndpoints(endpoints);

        // return endpoints;
    }
}