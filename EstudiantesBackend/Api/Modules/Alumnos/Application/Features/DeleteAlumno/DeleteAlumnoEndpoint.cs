using MediatR;

namespace Api.Modules.Alumnos.Application.Features.DeleteAlumno;


public static class DeleteAlumnoEndpoint
{
    public static void MapDeleteAlumnoEndpoint(this IEndpointRouteBuilder endpoints)
        => endpoints.MapDelete("/{id:guid}", DeleteAlumno);

    private static async Task<IResult> DeleteAlumno(
        Guid id,
        ISender sender,
        CancellationToken ct
    )
    {
        var command = new DeleteAlumnoCommand(id);
        var response = await sender.Send(command, ct);
        return Results.Ok(response);
    }
}