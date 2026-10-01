namespace Api.Modules.Materias.Application.Features.DeleteMateria;

using MediatR;


public static class DeleteMateriaEndpoint
{
    public static void MapDeleteMateriaEndpoint(this IEndpointRouteBuilder endpoints)
        => endpoints.MapDelete("/{id:guid}", DeleteMateria);

    private static async Task<IResult> DeleteMateria(
        Guid id,
        ISender sender,
        CancellationToken ct
    )
    {
        var command = new DeleteMateriaCommand(id);
        var response = await sender.Send(command, ct);
        return Results.Ok(response);
    }
}