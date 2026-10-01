

using MediatR;

namespace Api.Modules.Carreras.Application.Features.DeleteCarrera;


public static class DeleteCarreraEndpoint
{
    public static void MapDeleteCarreraEndpoint(this IEndpointRouteBuilder endpoints)
        => endpoints.MapDelete("/{id}", DeleteCarrera);


    public static async Task<IResult> DeleteCarrera(
        Guid id,
        ISender sender,
        CancellationToken ct
    )
    {
        var command = new DeleteCarreraCommand(id);
        var response = await sender.Send(command, ct);
        return Results.Ok(response);
    }
}