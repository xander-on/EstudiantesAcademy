using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Modules.Carreras.Application.Features.GetCarreras;



public static class GetCarrerasEndpoint
{
    public static void MapGetCarrerasEndpoint(this IEndpointRouteBuilder endpoints)
        => endpoints.MapGet("/", GetCarreras);

    private static async Task<IResult> GetCarreras(
        [FromQuery] Guid? id,
        ISender sender, 
        CancellationToken ct
    )
    {
        var carreras = await sender.Send(new GetCarrerasQuery(id), ct);
        return Results.Ok(carreras);
    }
}