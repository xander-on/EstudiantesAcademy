using MediatR;

namespace Api.Modules.Carreras.Application.Features.UpdateCarrera;


public static class UpdateCarreraEndpoint
{
    public static void MapUpdateCarreraEndpoint(this IEndpointRouteBuilder endpoints)
        => endpoints.MapPatch("/{id:guid}", UpdateCarrera);


    private static async Task<IResult> UpdateCarrera(
        Guid id,
        UpdateCarreraRequest request,
        ISender sender,
        CancellationToken ct
    )
    {
        var command = new UpdateCarreraCommand(
            id,
            request.Code,
            request.Name,
            request.Description,
            request.MateriasIds
        );

        var response = await sender.Send(command, ct);
        return Results.Ok(response);
    }
}