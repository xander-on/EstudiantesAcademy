using MediatR;

namespace Api.Modules.Carreras.Application.Features.CreateCarrera;

public static class CreateCarreraEndpoint
{
    public static void MapCreateCarreraEndpoint(this IEndpointRouteBuilder endpoints)
        => endpoints.MapPost("/", CreateCarrera);

    private static async Task<IResult> CreateCarrera(
        CreateCarreraRequest request,
        ISender sender,
        CancellationToken ct
    )
    {
        var command = new CreateCarreraCommand(
            request.Code,
            request.Name,
            request.Description,
            request.MateriasIds
        );

        var response = await sender.Send(command, ct);
        return Results.Ok(response);
    }
}
