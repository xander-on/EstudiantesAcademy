using MediatR;

namespace Api.Modules.Alumnos.Application.Features.UpdateAlumno;


public static class UpdateAlumnoEndpoint
{
    public static void MapUpdateAlumnoEndpoint(this IEndpointRouteBuilder endpoints)
        => endpoints.MapPatch("/{id:guid}", UpdateAlumno);


    private static async Task<IResult> UpdateAlumno(
        Guid id,
        UpdateAlumnoRequest request,
        ISender sender,
        CancellationToken ct
    )
    {
        var command = new UpdateAlumnoCommand(id, request.Dni, request.Name, request.LastName, request.Email);
        var response = await sender.Send(command, ct);
        return Results.Ok(response);
    }
}