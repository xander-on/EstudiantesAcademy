
using Api.Materias.Dtos;
using Application.Materias.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Materias;


public static class MateriasEndpoint
{
    public static void MapMateriasEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints
            .MapGroup("/api/materias")
            .WithTags("Materias");

        group.MapGet("/", GetMaterias);
        // routeGroupBuilder.MapGet("/{id}", GetMateriaById);
        group.MapPost("/", CreateMateria);
        // routeGroupBuilder.MapPut("/{id}", UpdateMateria);
        group.MapDelete("/{id:guid}", DeleteMateria);
    }

    private static async Task<IResult> GetMaterias(
        [AsParameters] GetMateriasRequest request,
        ISender sender, 
        CancellationToken ct
    )
    {
        var query    = new GetMateriasQuery(request.Id);
        var response = await sender.Send(query, ct);
        return Results.Ok(response);
    }


    private static async Task<IResult> CreateMateria(
        CreateMateriaRequest request,
        ISender sender, 
        CancellationToken ct
    )
    {
        var command = new CreateMateriaCommand(
            Name: request.Name,
            Description: request.Description
        );
        var response = await sender.Send(command, ct);
        return Results.Ok(response);
    }


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