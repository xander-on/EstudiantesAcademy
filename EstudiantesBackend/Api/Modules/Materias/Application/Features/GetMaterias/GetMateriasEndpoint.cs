using MediatR;

namespace Api.Modules.Materias.Application.Features.GetMaterias;



public static class GetMateriasEndpoint
{
    public static void MapGetMateriasEndpoint(this IEndpointRouteBuilder endpoints)
        => endpoints.MapGet("/", GetMaterias);


    private static async Task<IResult> GetMaterias(
        ISender sender, 
        CancellationToken ct
    )
    {
        var materias = await sender.Send(new GetMateriasQuery(), ct);
        return Results.Ok(materias);
    }
}