using MediatR;

namespace Api.Modules.Alumnos.Application.Features.GetAlumnos;


public static class GetAlumnosEndpoint
{
    public static void MapGetAlumnosEndpoint(this IEndpointRouteBuilder endpoints)
        => endpoints.MapGet("/", GetAlumnos);

    private static async Task<IResult> GetAlumnos(
        ISender sender, 
        CancellationToken ct
    )
    {
        var alumnos = await sender.Send(new GetAlumnosQuery(), ct);
        return Results.Ok(alumnos);
    }
}