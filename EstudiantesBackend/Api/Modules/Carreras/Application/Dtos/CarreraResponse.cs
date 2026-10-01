namespace Api.Modules.Carreras.Application.Dtos;

public record CarreraResponse(
    Guid Id,
    string Code,
    string Name,
    string Description,
    IReadOnlyList<Guid> MateriasIds
);