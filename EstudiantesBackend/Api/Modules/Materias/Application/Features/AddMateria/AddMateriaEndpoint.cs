using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Modules.Materias.Application.Features.AddMateria;


public static class AddMateriaEndpoint
{
    public static void MapAddMateriaEndpoint(this IEndpointRouteBuilder endpoints)
        => endpoints.MapPost("/", AddMateria);

    private static async Task<IResult> AddMateria(
        [FromBody] AddMateriaRequest request,
        ISender sender,
        CancellationToken ct
    )
    {
        var command = new AddMateriaCommand(request.Name, request.Description);
        var response = await sender.Send(command, ct);
        return Results.Ok(response);
    }
}