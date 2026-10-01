using MediatR;

namespace Api.Modules.Alumnos.Application.Features.CreateAlumno;

public static class CreateAlumnoEndpoint
{
    public static void MapCreateAlumnoEndpoint(this IEndpointRouteBuilder endpoints)
        => endpoints.MapPost("/", CreateAlumno);

    private static async Task<IResult> CreateAlumno(
        CreateAlumnoRequest request,
        ISender sender,
        CancellationToken ct
    )
    {
        var command = new CreateAlumnoCommand(
            request.Dni,
            request.Name,
            request.LastName,
            request.Email
        );

        var response = await sender.Send(command, ct);
        return Results.Ok(response);
    }
}
