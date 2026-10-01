using Api.Modules.Carreras.Application.Features.CreateCarrera;
using Api.Modules.Carreras.Application.Features.DeleteCarrera;
using Api.Modules.Carreras.Application.Features.GetCarreras;
using Api.Modules.Carreras.Application.Features.UpdateCarrera;
using Api.Modules.Carreras.Infrastructure;

namespace Api.Modules.Carreras;

public static class CarrerasModule
{
    public static void AddServices(IServiceCollection services)
    {
        services.AddScoped<CarrerasMateriasRepository>();
    }

    public static void MapCarrerasEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints
            .MapGroup("/api/carreras")
            .WithTags("Carreras");

        group.MapGetCarrerasEndpoint();
        group.MapCreateCarreraEndpoint();
        group.MapDeleteCarreraEndpoint();
        group.MapUpdateCarreraEndpoint();
    }
}