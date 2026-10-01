using MediatR;

namespace Api.Modules.Materias.Application.Features.UpdateMateria;


public static class UpdateMateriaEndpoint
{
    public static void MapUpdateMateriaEndpoint(this IEndpointRouteBuilder endpoints)
        => endpoints.MapPatch("/{id:guid}", UpdateMateria);


    private static async Task<IResult> UpdateMateria(
        Guid id,
        UpdateMateriaRequest request,
        ISender sender,
        CancellationToken ct
    )
    {
        var command = new UpdateMateriaCommand(id, request.Name, request.Description);
        var response = await sender.Send(command, ct);
        return Results.Ok(response);
    }
}